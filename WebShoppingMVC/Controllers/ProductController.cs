using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShoppingMVC.Data.Context;
using WebShoppingMVC.Data.Repository.Interface;
using WebShoppingMVC.Domain.Entity;
using WebShoppingMVC.Domain.ModelList;
using WebShoppingMVC.Services;
using WebShoppingMVC.Services.Interface;

namespace WebShoppingMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProductService _productService;
        AllList allList = new AllList();

        public ProductController(ApplicationDbContext dbContext, IProductService productService)
        {
            _dbContext = dbContext;
            _productService = productService;
        }

        public async Task<IActionResult> AllProducts()
        {
            allList.ListProductShirt = await _dbContext.Products.Where(n => n.Category.Name == "Shirt").ToListAsync();
            allList.ListProductShoes = await _dbContext.Products.Where(n => n.Category.Name == "Shoes").ToListAsync();
            allList.ListProductPants = await _dbContext.Products.Where(n => n.Category.Name == "Pants").ToListAsync();
            allList.ListProductAccessory = await _dbContext.Products.Where(n => n.Category.Name == "Accessory").ToListAsync();

            return View(allList);
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.Get(id));
        }

        public IActionResult AddToCart()
        {
            return View();
        }
    }
}
