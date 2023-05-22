using Microsoft.AspNetCore.Mvc;
using PXLPRO2023Shoppers02.Data;
using PXLPRO2023Shoppers02.Models;
using PXLPRO2023Shoppers02.Models.ViewModels;
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
			List<Products> products = _context.Product.ToList();
			List<ProductsCategories> categorys = _context.ProductCategory.ToList();
			var overzicht = from p in products
							join c in categorys on p.CategoryId equals c.CategoryId into table1
							from c in table1.ToList()
							select new CategoryViewModel
							{
								Categorys = c,
								Producten = p
							};
            if (overzicht == null)
            {
                return Problem("Entity set 'Overzicht' is null");
            }

            return View(overzicht);
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