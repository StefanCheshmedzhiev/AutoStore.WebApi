using AutoStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoStore.Data.Models
{
    public class Brand
    {
        public Brand()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.BrandNameMinLength)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
