﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Models.ViewModels;
using PXLPRO2023Shoppers02.Models;
using PXLPRO2023Shoppers02.Data;

namespace PXLPRO2023Shoppers02.Controllers
{
    public class ShopController : Controller
    {

        private readonly PXLPRO2023Shoppers02DbContext _context;

        public ShopController(PXLPRO2023Shoppers02DbContext context)
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

        public IActionResult Detail(int productId)
        {
            var product = _context.Product.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                // Handle the case where the product is not found
                return NotFound();
            }
            List<ProductsCategories> categories = _context.ProductCategory.ToList();
            var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            if (category == null)
            {
                // Handle the case where the category is not found
                return NotFound();
            }

            var model = new CategoryViewModel
            {
                Categorys = category,
                Producten = product
            };
            return View(model);
        }
    }
}
