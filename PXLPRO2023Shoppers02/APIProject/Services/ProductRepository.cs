using APIProject.Data;
using PXLPRO2023Shoppers02.Models;

namespace APIProject.Services
{
    public class ProductRepository : IProducts
    {
        private readonly ApiDbContext _context;
        public ProductRepository(ApiDbContext context)
        {
            _context = context; // collection of products that we retreive from our database
        }
        public IEnumerable<Products> GetAll()
        {
            return _context.Product;
        }

        public Products GetById(long id)
        {
            return _context.Product.FirstOrDefault(p => p.ProductId == id); 
        }

        public void Add(Products product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }
        public void Update(Products product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Products product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
    }
}
