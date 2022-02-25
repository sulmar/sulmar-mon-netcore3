using Domain;
using Infrastucture.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Infrastucture
{
    // Install-Package Microsoft.EntityFrameworkCore -version 3.1
    public class ShopperContext : DbContext
    {
        public ShopperContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Install-Package Microsoft.EntityFrameworkCore.SqlServer
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        }



    }
}
