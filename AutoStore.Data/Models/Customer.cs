using AutoStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoStore.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.CarsBuyed = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(GlobalConstants.EmailMinLength)]
        public string Email { get; set; }

        [Required]
        [MinLength(GlobalConstants.CustomerNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.CustomerNameMinLength)]
        public string LastName { get; set; }

        public virtual ICollection<Car> CarsBuyed { get; set; }
    }
}
