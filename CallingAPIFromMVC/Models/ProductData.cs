using AutoStore.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallingAPIFromMVC.Models
{
    public class ProductData
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
