using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Models;
using System;

namespace PXLPRO2023Shoppers02.Data
{
    public class PXLPRO2023Shoppers02DbContext : IdentityDbContext
    {
        public PXLPRO2023Shoppers02DbContext(DbContextOptions<PXLPRO2023Shoppers02DbContext> options) : base(options)
        {

        }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<ProductsCategories> ProductCategory { get; set; }
        public DbSet<OrdersLines> OrdersLines { get; set; }
    }
}
