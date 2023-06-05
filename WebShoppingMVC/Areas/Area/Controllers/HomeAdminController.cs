using Microsoft.AspNetCore.Mvc;

namespace WebShoppingMVC.Areas.Area.Controllers
{
    public class HomeAdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
