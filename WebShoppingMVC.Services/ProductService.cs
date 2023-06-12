using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Contracts.Dtos;
using WebShoppingMVC.Data.Context;
using WebShoppingMVC.Data.Repository;
using WebShoppingMVC.Data.Repository.Interface;
using WebShoppingMVC.Domain.Entity;
using WebShoppingMVC.Services.Interface;

namespace WebShoppingMVC.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly ApplicationDbContext _dbContext;

        public ProductService(IBaseRepository<Product> baseRepository, ApplicationDbContext dbContext)
        {
            _baseRepository = baseRepository;
            _dbContext = dbContext;
        }

        public async Task<Product> Create(ProductDto productDto)
        {
            if (productDto.File != null && productDto.File.Length > 0)
            {
                //Lấy tên file
                string fileName = productDto.File.FileName;
                //dùng để path các đường dẫn
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagesProduct", fileName);
                var stream = new FileStream(path, FileMode.Create);
                await productDto.File.CopyToAsync(stream);
                //Tạo đường dẫn để lưu vào db
                string url = "/ImagesProduct/" + fileName;
                var product = new Product()
                {
                    Name = productDto.Name,
                    CategoryId = productDto.CategoryId,
                    Description = productDto.Description,
                    Image = url,
                    Price = productDto.Price,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                await _baseRepository.Create(product);
                return product;
            }
            return null;
            
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public async Task<Product> Get(int id)
        {
            return await _dbContext.Products.Include(n => n.Category).FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.OrderByDescending(n => n.Id).Include(n => n.Category).ToListAsync();
        }

        public async Task<Product> Update(ProductDto productDto)
        {
            var query = await _baseRepository.GetById(productDto.Id);
            if (productDto.File != null && productDto.File.Length > 0)
            {
                //Lấy tên file
                string fileName = productDto.File.FileName;
                //dùng để path các đường dẫn
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagesProduct", fileName);
                var stream = new FileStream(path, FileMode.Create);
                await productDto.File.CopyToAsync(stream);
                //Tạo đường dẫn để lưu vào db
                string url = "/ImagesProduct/" + fileName;
                query.Description = productDto.Description;
                query.Price = productDto.Price;
                query.CategoryId = productDto.CategoryId;
                query.Name = productDto.Name;
                query.Image = url;
                query.UpdatedDate = DateTime.Now;
                await _baseRepository.Update(query);
                return query;
            }
            return null;
        }
    }
}
