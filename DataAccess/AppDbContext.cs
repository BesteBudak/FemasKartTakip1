using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ApprovalProcess> ApprovalProcesses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Software>()
                .HasOne(c => c.ApprovalProcess)
                .WithOne(a => a.Software)
                .HasForeignKey<ApprovalProcess>(a => a.SoftwareId);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.Stock)
                .WithOne(a => a.Card)
                .HasForeignKey<Stock>(a => a.CardId);

            modelBuilder.Entity<Card>()
                .HasMany(c => c.Softwares)
                .WithMany(s => s.Cards);

            modelBuilder.Entity<User>()
        .HasOne(u => u.Department)
        .WithMany(d => d.Users)
        .HasForeignKey(u => u.DepartmentId);
        }
    }

}
