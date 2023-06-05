using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Contracts.Dtos;
using WebShoppingMVC.Data.Repository;
using WebShoppingMVC.Data.Repository.Interface;
using WebShoppingMVC.Domain.Entity;
using WebShoppingMVC.Services.Interface;

namespace WebShoppingMVC.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _baseRepository;

        public CategoryService(IBaseRepository<Category> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<Category> Create(CategoryDto categoryDto)
        {
            var create = new Category()
            {
                Name = categoryDto.Name,
                Code = categoryDto.Code,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            await _baseRepository.Create(create);
            return create;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _baseRepository.GetAllAsync();
        }

        public Task<Category> Update(int id, CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
