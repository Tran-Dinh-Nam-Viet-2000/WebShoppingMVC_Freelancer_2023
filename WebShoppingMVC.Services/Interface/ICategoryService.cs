using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Contracts.Dtos;
using WebShoppingMVC.Domain.Entity;

namespace WebShoppingMVC.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<CategoryDto> Get(int id);
        Task<Category> Create(CategoryDto categoryDto);
        Task<Category> Update(int id, CategoryDto categoryDto);
        void Delete(int id);
    }
}
