using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
   
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<SoftwareRevision> SoftwareRevisions { get; set; }
       
        public DbSet<ApprovalProcess> ApprovalProcesses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CardField> CardFields { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardField>()
     .Property(f => f.PhotoUrls)
     .HasConversion(
         v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
         v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
     );

            modelBuilder.Entity<Software>()
                .HasOne(c => c.ApprovalProcess)
                .WithOne(a => a.Software)
                .HasForeignKey<ApprovalProcess>(a => a.SoftwareId);

            //modelBuilder.Entity<CardField>()
            //.Property(f => f.PhotoUrls)
            //.HasConversion(converter);


            modelBuilder.Entity<Card>()
                .HasMany(c => c.Softwares)
                .WithMany(s => s.Cards);

            modelBuilder.Entity<User>()
        .HasOne(u => u.Department)
        .WithMany(d => d.Users)
        .HasForeignKey(u => u.DepartmentId);
        
            modelBuilder.Entity<CardField>()
        .HasOne(u => u.Card)
        .WithMany(d => d.Fields)
        .HasForeignKey(u => u.CardId);
        }
    }

}
