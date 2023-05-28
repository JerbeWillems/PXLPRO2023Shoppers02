using Microsoft.AspNetCore.Mvc;

namespace PXLPRO2023Shoppers02.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WinkelKar()
        {
            return View();
        }
    }
}
