using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Models.ViewModels;
using PXLPRO2023Shoppers02.Models;
using PXLPRO2023Shoppers02.Data;

namespace PXLPRO2023Shoppers02.Controllers
{
    public class ProductController : Controller
    {
        private readonly PXLPRO2023Shoppers02DbContext _context;

        public ProductController(PXLPRO2023Shoppers02DbContext context)
        {
            _context = context;
        }

        //Get all products from DB
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

        public IActionResult Create() { 


            return View();
        }

        [HttpPost]
        public IActionResult Create(Products obj)
        {
            if (ModelState.IsValid)
            {
                _context.Product.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the appropriate action after successful creation
            }

            return View(obj);
        }

    }
}
