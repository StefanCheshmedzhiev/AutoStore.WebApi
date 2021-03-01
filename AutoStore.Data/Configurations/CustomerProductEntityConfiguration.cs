using AutoStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Data.Configurations
{
    public class CustomerProductEntityConfiguration : IEntityTypeConfiguration<CustomerProduct>
    {
        public void Configure(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder
                .HasKey(cp =>
                    new { cp.CustomerId, cp.ProductId });
        }
    }
}
