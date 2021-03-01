using AutoStore.Common.DTOs.Customers.InputModels;
using AutoStore.Common.DTOs.Customers.OutputModels;
using AutoStore.Data.Models;
using AutoStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoStore.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ListAllCustomersDTO>> Get() => customerService
            .GetAll()
            .ToList();

        [HttpGet("{id}")]
        public ActionResult<GetCustomerByIdDTO> Get(int id)
        {
            GetCustomerByIdDTO customerById = customerService.GetById(id);
            if (customerById == null)
            {
                return this.NotFound();
            }
            return customerById;
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddCustomerDTO addCustomerDTO)
        {
            await customerService.InsertCustomer(addCustomerDTO);
            return Ok(addCustomerDTO);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EditCustomerDTO editCustomerDTO)
        {
            await customerService.EditCustomer(id, editCustomerDTO);
            return Ok(editCustomerDTO);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            return await customerService.Delete(id);

        }
    }
}
