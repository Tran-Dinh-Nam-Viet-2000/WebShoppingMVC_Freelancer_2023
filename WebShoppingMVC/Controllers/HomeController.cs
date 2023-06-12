using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShoppingMVC.Data.Context;
using WebShoppingMVC.Data.Repository.Interface;
using WebShoppingMVC.Domain.Entity;
using WebShoppingMVC.Domain.ModelList;
using WebShoppingMVC.Models;
using WebShoppingMVC.Services;
using WebShoppingMVC.Services.Interface;

namespace WebShoppingMVC.Controllers
{
	public class HomeController : Controller
	{
        private readonly ApplicationDbContext _dbContext;
        AllList allList = new AllList();
        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult> Index()
		{
            allList.ListProduct = _dbContext.Products.Where(n => n.CategoryId == 23).ToList();
			return View(allList);
		}
	}
}