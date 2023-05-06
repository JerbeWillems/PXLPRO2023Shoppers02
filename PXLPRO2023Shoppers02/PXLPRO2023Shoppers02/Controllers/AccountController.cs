using Microsoft.AspNetCore.Mvc;

namespace PXLPRO2023Shoppers02.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            // loginlogica nog in verwerken
            return View();
        }
        [HttpPost]
        public IActionResult FacebookLogin()
        {
            // loginlogica nog in verwerken
            return View();
        }
        [HttpPost]
        public IActionResult Register()
        {
            // loginlogica nog in verwerken
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            // loginlogica nog in verwerken
            return View();
        }
    }
}
