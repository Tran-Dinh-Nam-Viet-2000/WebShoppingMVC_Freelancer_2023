using Microsoft.AspNetCore.Mvc;
using WebShoppingMVC.Contracts.Dtos;
using WebShoppingMVC.Services.Interface;

namespace WebShoppingMVC.Areas.Area.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAll());
        }

        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            return View(await _categoryService.Create(categoryDto));
        }
    }
}
