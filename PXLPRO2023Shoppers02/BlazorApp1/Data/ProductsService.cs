using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Data; 
using PXLPRO2023Shoppers02.Models;
public class ProductService
{
    private readonly PXLPRO2023Shoppers02DbContext _dbContext;

    public ProductService(PXLPRO2023Shoppers02DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Products>> GetAllProducts()
    {
        return await _dbContext.Product.ToListAsync();
    }

    public async Task<bool> CreateProduct(Products product)
    {
        try
        {
            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            var product = await _dbContext.Product.FindAsync(productId);
            if (product != null)
            {
                _dbContext.Product.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}