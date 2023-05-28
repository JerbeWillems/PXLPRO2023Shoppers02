using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Models;
using PXLPRO2023Shoppers02.ViewModels;

namespace BlazorProducts.Data
{
    public class ApiDbContextBlazor : DbContext
    {
        public ApiDbContextBlazor(DbContextOptions<ApiDbContextBlazor> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<OrderLine> OrdersLines { get; set; }
        public DbSet<UserInfoModel> UserInfo { get; set; }


    }
}
