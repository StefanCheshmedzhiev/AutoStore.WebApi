using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStore.Common.DTOs.Customers.InputModels
{
    public class AddCustomerDTO
    {
        
        public int Id { get; set; }

        
        public string Username { get; set; }

        
        public string Password { get; set; }

        
        public string Email { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }
    }
}
