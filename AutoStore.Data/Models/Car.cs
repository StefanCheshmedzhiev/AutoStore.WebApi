using AutoStore.Common;
using AutoStore.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoStore.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CarModelNameMinLength)]
        public string ModelName { get; set; }

        public CarType CarType { get; set; }

        [Range(GlobalConstants.CarMinAge, GlobalConstants.CarMaxAge)]
        public byte Age { get; set; }

        public bool IsSold { get; set; }

        [Range(GlobalConstants.SellableMinPrice, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
