using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Models;

namespace APIProject.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Products> Product { get; set; }
    }
}
