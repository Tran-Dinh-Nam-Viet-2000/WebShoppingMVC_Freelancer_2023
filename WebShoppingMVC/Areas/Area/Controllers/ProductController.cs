using Microsoft.AspNetCore.Mvc;
using WebShoppingMVC.Data.Context;

namespace WebShoppingMVC.Areas.Area.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var products = _dbContext.Products.ToList();
            return View(products);
        }
    }
}
