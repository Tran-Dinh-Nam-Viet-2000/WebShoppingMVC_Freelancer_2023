using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShoppingMVC.Contracts.Dtos;
using WebShoppingMVC.Data.Context;
using WebShoppingMVC.Services.Interface;

namespace WebShoppingMVC.Areas.Area.Controllers
{
    public class Product_AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ApplicationDbContext _dbContext;

        public Product_AdminController(IProductService productService, ApplicationDbContext dbContext)
        {
            _productService = productService;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            //chọn kiểu dropdownlist
            
            return View(await _productService.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.Get(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = _dbContext.Categories.Where(n => n.IsActive == true).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productService.Create(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.CategoryList = _dbContext.Categories.Where(n => n.IsActive == true).ToList();
            return View(await _productService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productService.Update(productDto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
