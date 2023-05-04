using Microsoft.AspNetCore.Mvc;
using PXLPRO2023Shoppers02.Data;
using PXLPRO2023Shoppers02.Models;
using System.Diagnostics;

namespace PXLPRO2023Shoppers02.Controllers
{
	public class HomeController : Controller
	{
        private readonly PXLPRO2023Shoppers02DbContext _context;

        public HomeController(PXLPRO2023Shoppers02DbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}