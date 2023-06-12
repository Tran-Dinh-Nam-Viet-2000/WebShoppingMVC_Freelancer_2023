using Microsoft.AspNetCore.Mvc;
using WebShoppingMVC.Data.Repository.Interface;
using WebShoppingMVC.Domain.Entity;
using WebShoppingMVC.Domain.ModelList;

namespace WebShoppingMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaseRepository<Product> _baseRepository;

        public ProductController(IBaseRepository<Product> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _baseRepository.GetById(id));
        }
    }
}
