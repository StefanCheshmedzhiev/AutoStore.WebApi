using AutoStore.Common.DTOs.Customers.InputModels;
using AutoStore.Common.DTOs.Customers.OutputModels;
using AutoStore.Common.Exceptions;
using AutoStore.Data;
using AutoStore.Data.Models;
using AutoStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AutoStoreDbContext dbContext;

        public CustomerService(AutoStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Customer> Delete(int id)
        {
            var dbCustomer = dbContext.Customers
                .FirstOrDefault(x => x.Id == id);

            this.dbContext.Remove(dbCustomer);
            await this.dbContext.SaveChangesAsync();
            return dbCustomer;
        }

        public async Task EditCustomer(int id, EditCustomerDTO editCustomerDTO)
        {
            var dbCustomer = dbContext.Customers
                .FirstOrDefault(x => x.Id == id);


            //Parameter tampering

            dbCustomer.FirstName = editCustomerDTO.FirstName;
            dbCustomer.LastName = editCustomerDTO.LastName;
            dbCustomer.Email = editCustomerDTO.Email;

            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<ListAllCustomersDTO> GetAll()
        {
            var customers = this.dbContext
                .Customers
                .Select(x => new ListAllCustomersDTO
                {
                    Id = x.Id,
                    Username = x.Username,
                    Password = x.Password,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();

            return customers;
        }

        public GetCustomerByIdDTO GetById(int id)
        {
            var customer = this.dbContext.Customers
               .Select(x => new GetCustomerByIdDTO
               {
                   Id = x.Id,
                   Username = x.Username,
                   Password = x.Password,
                   Email = x.Email,
                   FirstName = x.FirstName,
                   LastName = x.LastName
               })
               .FirstOrDefault(p => p.Id == id);


            if (customer == null)
            {
                throw new ArgumentException(ExceptionMessages.CustomerNotFound);
            }

            return customer;
        }

        public async Task InsertCustomer(AddCustomerDTO addCustomerDTO)
        {
            var customer = new Customer
            {
                Id = addCustomerDTO.Id,
                Username = addCustomerDTO.Username,
                Password = addCustomerDTO.Password,
                Email = addCustomerDTO.Email,
                FirstName = addCustomerDTO.FirstName,
                LastName = addCustomerDTO.LastName
            };
            this.dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
        }
    }
}
