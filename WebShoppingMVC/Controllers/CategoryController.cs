using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShoppingMVC.Data.Context;
using WebShoppingMVC.Data.Repository.Interface;
using WebShoppingMVC.Domain.Entity;
using WebShoppingMVC.Domain.ModelList;

namespace WebShoppingMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        AllList allList = new AllList();

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Shirt()
        {
            allList.ListProduct = await _dbContext.Products.Where(n => n.CategoryId == 21).ToListAsync();
            return View(allList);
        }

        public async Task<IActionResult> Pants()
        {
            allList.ListProduct = await _dbContext.Products.Where(n => n.CategoryId == 23).ToListAsync();
            return View(allList);
        }

        public async Task<IActionResult> Shoes()
        {
            allList.ListProduct = await _dbContext.Products.Where(n => n.CategoryId == 25).ToListAsync();
            return View(allList);
        }

        public async Task<IActionResult> Accessory()
        {
            allList.ListProduct = await _dbContext.Products.Where(n => n.CategoryId == 27).ToListAsync();
            return View(allList);
        }
    }
}
