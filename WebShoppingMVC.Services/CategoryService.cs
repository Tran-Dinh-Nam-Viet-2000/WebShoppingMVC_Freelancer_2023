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
            _baseRepository.Delete(id);
        }

        public async Task<Category> Get(int id)
        {
            return await _baseRepository.GetById(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<Category> Update(CategoryDto categoryDto)
        {
            var query = await _baseRepository.GetById(categoryDto.Id);
            query.Code = categoryDto.Code;
            query.Name = categoryDto.Name;
            query.UpdatedDate = DateTime.Now;
            await _baseRepository.Update(query);

            return query;
        }
    }
}
