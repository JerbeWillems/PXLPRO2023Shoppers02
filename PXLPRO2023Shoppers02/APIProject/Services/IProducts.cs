using PXLPRO2023Shoppers02.Models;

namespace APIProject.Services
{
    public interface IProducts
    {
        IEnumerable<Products> GetAll();
        Products GetById(long id);
        void Add(Products product);
        void Update(Products product);
        void Delete(Products product);
    }
}
