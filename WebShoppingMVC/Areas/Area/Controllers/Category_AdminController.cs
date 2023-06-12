using Microsoft.AspNetCore.Mvc;
using WebShoppingMVC.Contracts.Dtos;
using WebShoppingMVC.Domain.Entity;
using WebShoppingMVC.Services.Interface;

namespace WebShoppingMVC.Areas.Area.Controllers
{
    public class Category_AdminController : Controller
    {
        private readonly ICategoryService _categoryService;

        public Category_AdminController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _categoryService.Get(id));
        }

        public async Task<IActionResult> Create(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(await _categoryService.Create(category));
        }

        public async Task<IActionResult> Update(CategoryDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
