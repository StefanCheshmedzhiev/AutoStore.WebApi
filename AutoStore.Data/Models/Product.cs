using AutoStore.Common;
using AutoStore.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoStore.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.ProductNameMinLength)]
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        [Range(GlobalConstants.SellableMinPrice, Double.MaxValue)]
        public decimal Price { get; set; }
    }
}
