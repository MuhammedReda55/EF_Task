using EF_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Task.Data
{
    internal class ApplicationDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SalesDatabase;Integrated Security=True;" +
                "TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            base.OnModelCreating(modelBuilder);

            //Name (up to 50 characters, unicode)
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Product>()
                .Property(p=>p.Price)
                .HasPrecision(8, 2);

            //Name (up to 100 characters, unicode)
            modelBuilder.Entity<Customer>()
            .Property(c=>c.Name)
             .HasColumnType("varchar(100)");

            //Email (up to 80 characters, not unicode)
            modelBuilder.Entity<Customer>()
           .Property(c => c.Email)
           .HasMaxLength(80)
            .IsUnicode(true);

            //Name (up to 80 characters, unicode)
            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .HasColumnType("VARCHAR(80)");

            // For table Products add string column Description, The migration should be named: "ProductsAddColumnDescription".
            modelBuilder.Entity<Product>()
                .Property<string>("Description")

            .HasColumnType("varchar(50)");



            //For table Sales Add Date column, Name the migration “SalesAddDateDefault”.
            modelBuilder.Entity<Sale>()
                .Property<DateTime>("Date");

        }
    }
}
