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
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<ProductsCategories> ProductCategory { get; set; }
        public DbSet<OrdersLines> OrdersLines { get; set; }
        public DbSet<UserInfoModel> UserInfo { get; set; }


    }
}
