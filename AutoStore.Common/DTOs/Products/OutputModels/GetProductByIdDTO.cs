using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Common.DTOs.Products.OutputModels
{
    public class GetProductByIdDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ProductType { get; set; }

        public decimal Price { get; set; }
    }
}
