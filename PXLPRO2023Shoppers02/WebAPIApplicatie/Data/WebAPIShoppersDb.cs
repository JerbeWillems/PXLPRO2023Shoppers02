using Microsoft.EntityFrameworkCore;
using WebAPIApplicatie.Model;

namespace WebAPIApplicatie.Data
{
    public class WebAPIShoppersDb : DbContext
    {
        public WebAPIShoppersDb(DbContextOptions<WebAPIShoppersDb> options) : base(options)
        {

        }

        public DbSet<Stock> Stock { get; set; }
    }
}
