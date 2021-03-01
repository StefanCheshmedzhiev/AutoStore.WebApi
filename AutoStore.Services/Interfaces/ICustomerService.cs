using AutoStore.Common.DTOs.Customers.InputModels;
using AutoStore.Common.DTOs.Customers.OutputModels;
using AutoStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoStore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task InsertCustomer(AddCustomerDTO addCustomerDTO);
        GetCustomerByIdDTO GetById(int id);


        ICollection<ListAllCustomersDTO> GetAll();
        Task EditCustomer(int id, EditCustomerDTO editCustomerDTO);
        Task<Customer> Delete(int id);
    }
}
