using AutoStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoStore.Data.Models
{
    public class CustomerProduct
    {
        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Range(GlobalConstants.CustomerProductMinQuantity, Int32.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
