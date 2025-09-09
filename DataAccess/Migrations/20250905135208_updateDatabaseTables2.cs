using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updateDatabaseTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
-- 1) Tablo yoksa oluştur (hedef şema ile)
IF OBJECT_ID(N'[dbo].[SoftwareRevisions]', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[SoftwareRevisions](
        [Id] INT IDENTITY(1,1) NOT NULL,
        [SoftwareId] INT NULL,                       -- nullable hedef
        [FileType] NVARCHAR(MAX) NOT NULL,
        [Uploader] NVARCHAR(MAX) NOT NULL,
        [ApprovalCode] NVARCHAR(MAX) NOT NULL,
        [Notes] NVARCHAR(MAX) NOT NULL,
        [FilePath] NVARCHAR(MAX) NOT NULL,           -- hedefte gerekli
        CONSTRAINT [PK_SoftwareRevisions] PRIMARY KEY ([Id])
    );
END;

-- 2) FilePath kolonu yoksa ekle (NOT NULL için geçici default kullan)
IF OBJECT_ID(N'[dbo].[SoftwareRevisions]', N'U') IS NOT NULL
BEGIN
    IF COL_LENGTH('dbo.SoftwareRevisions','FilePath') IS NULL
    BEGIN
        ALTER TABLE [dbo].[SoftwareRevisions] ADD [FilePath] NVARCHAR(MAX) NOT NULL CONSTRAINT DF_SoftwareRevisions_FilePath DEFAULT('');
        ALTER TABLE [dbo].[SoftwareRevisions] DROP CONSTRAINT DF_SoftwareRevisions_FilePath;
    END;

    -- 3) SoftwareId nullable değilse nullable yap
    IF EXISTS(
        SELECT 1
        FROM sys.columns
        WHERE object_id = OBJECT_ID('dbo.SoftwareRevisions')
          AND name = 'SoftwareId'
          AND is_nullable = 0
    )
    BEGIN
        ALTER TABLE [dbo].[SoftwareRevisions] ALTER COLUMN [SoftwareId] INT NULL;
    END;

    -- 4) Eski FK varsa düşür (adı uyuşan)
    IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SoftwareRevisions_Softwares_SoftwareId')
    BEGIN
        ALTER TABLE [dbo].[SoftwareRevisions] DROP CONSTRAINT [FK_SoftwareRevisions_Softwares_SoftwareId];
    END;

    -- 5) Softwares tablosu varsa FK ekle (yoksa zaten eklenemez)
    IF OBJECT_ID(N'[dbo].[Softwares]', N'U') IS NOT NULL
    BEGIN
        ALTER TABLE [dbo].[SoftwareRevisions]  WITH CHECK
        ADD CONSTRAINT [FK_SoftwareRevisions_Softwares_SoftwareId]
        FOREIGN KEY([SoftwareId]) REFERENCES [dbo].[Softwares]([Id]);
    END;

    -- (Opsiyonel ama iyi olur) Index yoksa ekle
    IF NOT EXISTS (
        SELECT 1 FROM sys.indexes 
        WHERE name = 'IX_SoftwareRevisions_SoftwareId' 
          AND object_id = OBJECT_ID('dbo.SoftwareRevisions')
    )
    BEGIN
        CREATE INDEX [IX_SoftwareRevisions_SoftwareId] ON [dbo].[SoftwareRevisions]([SoftwareId]);
    END;
END;
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'[dbo].[SoftwareRevisions]', N'U') IS NOT NULL
BEGIN
    IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_SoftwareRevisions_Softwares_SoftwareId')
    BEGIN
        ALTER TABLE [dbo].[SoftwareRevisions] DROP CONSTRAINT [FK_SoftwareRevisions_Softwares_SoftwareId];
    END;

    IF EXISTS (
        SELECT 1 FROM sys.indexes 
        WHERE name = 'IX_SoftwareRevisions_SoftwareId' 
          AND object_id = OBJECT_ID('dbo.SoftwareRevisions')
    )
    BEGIN
        DROP INDEX [IX_SoftwareRevisions_SoftwareId] ON [dbo].[SoftwareRevisions];
    END;

    IF COL_LENGTH('dbo.SoftwareRevisions','FilePath') IS NOT NULL
    BEGIN
        ALTER TABLE [dbo].[SoftwareRevisions] DROP COLUMN [FilePath];
    END;

    -- (İstersen SoftwareId'yi tekrar NOT NULL'a çevirirsin)
    -- ALTER TABLE [dbo].[SoftwareRevisions] ALTER COLUMN [SoftwareId] INT NOT NULL;
END;
");
        }
    }
}
