using Microsoft.AspNetCore.Mvc;

namespace WebShoppingMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
