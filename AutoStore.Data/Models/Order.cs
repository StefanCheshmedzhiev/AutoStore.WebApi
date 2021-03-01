using AutoStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AutoStore.Data.Models
{
    public class Order
    {
        public Order()
        {           
            this.CustomerProducts =
                new HashSet<CustomerProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.TownNameMinLength)]
        public string Town { get; set; }

        [Required]
        [MinLength(GlobalConstants.AddressTextMinLength)]
        public string Address { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }

        public decimal TotalPrice => this.CustomerProducts
            .Sum(cp => cp.Product.Price * cp.Quantity);
    }
}
