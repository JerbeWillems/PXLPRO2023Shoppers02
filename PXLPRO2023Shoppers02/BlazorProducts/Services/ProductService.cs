using BlazorProducts.Data;
using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Models;

namespace BlazorProducts.Services
{
    public class ProductService
    {
        private readonly ApiDbContextBlazor _context;

        public ProductService(ApiDbContextBlazor apiDbContext)
        {
            _context = apiDbContext;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();

        }
        public async Task<bool> AddNewProduct(Products product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
