using AutoStore.Common.DTOs.Products.InputModels;
using AutoStore.Common.DTOs.Products.OutputModels;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ListAllProductsDTO>> GetAllProducts()
        {
            var allProducts = service
                .GetAll()
                .ToList();
            return allProducts;

        }
        [HttpGet("{id}")]
        public ActionResult<GetProductByIdDTO> GetById(int id)
        {
            GetProductByIdDTO productById = service.GetById(id);
            if (productById == null)
            {
                return this.NotFound();
            }
            return productById;
        }
        [HttpGet("GetByProductType/{type}")]
        public ActionResult<IEnumerable<ListAllProductsByProductTypeDTO>> GetAllProductsByProductType(string type)
        {
            var productsByProductType = service.ListAllByProductType(type).ToList();
            return productsByProductType;
        }
        [HttpPost]
        public async Task<ActionResult<AddProductDTO>> Post(AddProductDTO productDTO)
        {
            await service.InsertProduct(productDTO);
            return Ok(productDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EditProductDTO>> Put(int id, EditProductDTO editProductDTO)
        {
            await service.EditProduct(id, editProductDTO);
            return Ok(editProductDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            return await service.Delete(id);

        }
    }
}
