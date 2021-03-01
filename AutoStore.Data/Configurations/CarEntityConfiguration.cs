using AutoStore.Common;
using AutoStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Data.Configurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .Property(p => p.ModelName)
                .HasMaxLength(GlobalConstants.CarModelNameMaxLength)
                .IsUnicode(true);
        }
    }
}
