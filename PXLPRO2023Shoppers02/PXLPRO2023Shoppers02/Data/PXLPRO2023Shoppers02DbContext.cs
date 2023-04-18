using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace PXLPRO2023Shoppers02.Data
{
    public class PXLPRO2023Shoppers02DbContext : IdentityDbContext
    {
        public PXLPRO2023Shoppers02DbContext(DbContextOptions<PXLPRO2023Shoppers02DbContext> options) : base(options)
        {

        }
    }
}
