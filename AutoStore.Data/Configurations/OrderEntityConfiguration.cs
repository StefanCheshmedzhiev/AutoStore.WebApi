using AutoStore.Common;
using AutoStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Data.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.Town)
                .HasMaxLength(GlobalConstants.TownNameMaxLength)
                .IsUnicode(true);

            builder
                .Property(o => o.Address)
                .HasMaxLength(GlobalConstants.AddressTextMaxLength)
                .IsUnicode(true);

            builder
                .Ignore(o => o.TotalPrice);
        }
    }
}
