using AutoStore.Common;
using AutoStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Data
{
    public class AutoStoreDbContext : DbContext
    {
        public AutoStoreDbContext()
        {

        }

        public AutoStoreDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutoStoreDbContext).Assembly);
        }
    }
}
