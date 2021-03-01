using AutoStore.Common;
using AutoStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Data.Configurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(c => c.Username)
                .HasMaxLength(GlobalConstants.UsernameMaxLength)
                .IsUnicode(false);

            builder
                .Property(c => c.Email)
                .HasMaxLength(GlobalConstants.EmailMaxLength)
                .IsUnicode(false);

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(GlobalConstants.CustomerNameMaxLength)
                .IsUnicode(true);

            builder
                .Property(c => c.LastName)
                .HasMaxLength(GlobalConstants.CustomerNameMaxLength)
                .IsUnicode(true);
        }
    }
}