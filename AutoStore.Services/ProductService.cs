using AutoStore.Common.DTOs.Products.InputModels;
using AutoStore.Common.DTOs.Products.OutputModels;
using AutoStore.Common.Enums;
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
    public class ProductService : IProductService
    {
        private readonly AutoStoreDbContext dbContext;

        public ProductService(AutoStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertProduct(AddProductDTO productDTO)
        {
            var product = new Product
            {
                Id = productDTO.ProductId,
                Name = productDTO.Name,
                ProductType = (ProductType)Enum.Parse(typeof(ProductType), productDTO.ProductType, true),
                Price = productDTO.Price
            };
            this.dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
        }


        public ICollection<ListAllProductsDTO> GetAll()
        {
            var products = this.dbContext
                .Products
                .Select(x => new ListAllProductsDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductType = x.ProductType.ToString(),
                    Price = x.Price
                })
                .ToList();

            return products;
        }

        public GetProductByIdDTO GetById(int id)
        {
            var product = this.dbContext.Products
                .Select(x => new GetProductByIdDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductType = x.ProductType.ToString(),
                    Price = x.Price
                })
                .FirstOrDefault(p => p.Id == id);


            if (product == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            return product;
        }
        public ICollection<ListAllProductsByProductTypeDTO> ListAllByProductType(string type)
        {
            ProductType productType;
            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            var products = this.dbContext
                 .Products
                 .Where(p => p.ProductType == productType)
                 .Select(x => new ListAllProductsByProductTypeDTO
                 {
                     Name = x.Name,
                     Price = x.Price

                 })
                 .ToList();
            return products;
        }
        public async Task EditProduct(int id, EditProductDTO editProductDTO)
        {
            var dbProduct = dbContext.Products
                .FirstOrDefault(x => x.Id == id);


            //Parameter tampering

            dbProduct.Price = editProductDTO.Price;

            await this.dbContext.SaveChangesAsync();
        }
        public async Task<Product> Delete(int id)
        {
            var dbProduct = dbContext.Products
                .FirstOrDefault(x => x.Id == id);

            this.dbContext.Remove(dbProduct);
            await this.dbContext.SaveChangesAsync();
            return dbProduct;
        }
    }
}
