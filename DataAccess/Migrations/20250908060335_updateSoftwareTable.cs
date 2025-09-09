using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateSoftwareTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareRevisions_Softwares_SoftwareId",
                table: "SoftwareRevisions");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Softwares");

            migrationBuilder.AlterColumn<int>(
                name: "SoftwareId",
                table: "SoftwareRevisions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareRevisions_Softwares_SoftwareId",
                table: "SoftwareRevisions",
                column: "SoftwareId",
                principalTable: "Softwares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftwareRevisions_Softwares_SoftwareId",
                table: "SoftwareRevisions");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Softwares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SoftwareId",
                table: "SoftwareRevisions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftwareRevisions_Softwares_SoftwareId",
                table: "SoftwareRevisions",
                column: "SoftwareId",
                principalTable: "Softwares",
                principalColumn: "Id");
        }
    }
}
