using AutoStore.Common.DTOs.Products.InputModels;
using AutoStore.Common.DTOs.Products.OutputModels;
using AutoStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoStore.Services.Interfaces
{
    public interface IProductService
    {
        Task InsertProduct(AddProductDTO productDTO);
        GetProductByIdDTO GetById(int id);


        ICollection<ListAllProductsDTO> GetAll();
        Task EditProduct(int id, EditProductDTO editProductDTO);
        Task<Product> Delete(int id);
    }
}
