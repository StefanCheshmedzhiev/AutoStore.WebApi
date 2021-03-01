using AutoStore.Common;
using AutoStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Data.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasAlternateKey(p => p.Name);

            builder
                .Property(p => p.Name)
                .HasMaxLength(GlobalConstants.ProductNameMaxLength)
                .IsUnicode(true);
        }
    }
}
