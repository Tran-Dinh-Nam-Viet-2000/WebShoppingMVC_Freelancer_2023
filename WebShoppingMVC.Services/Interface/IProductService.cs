using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Contracts.Dtos;
using WebShoppingMVC.Domain.Entity;

namespace WebShoppingMVC.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(int id);
        Task<Product> Create(ProductDto productDto);
        Task<Product> Update(ProductDto productDto);
        void Delete(int id);
    }
}
