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

        public ProductController(ApplicationDbContext dbContext, IProductService productService)
        {
            _dbContext = dbContext;
            _productService = productService;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.Get(id));
        }
    }
}
