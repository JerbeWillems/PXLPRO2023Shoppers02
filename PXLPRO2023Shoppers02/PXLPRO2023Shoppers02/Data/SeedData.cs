using Microsoft.AspNetCore.Identity;
using PXLPRO2023Shoppers02.Models;

namespace PXLPRO2023Shoppers02.Data
{
    public static class SeedData
    {
        static PXLPRO2023Shoppers02DbContext? _context;
        static RoleManager<IdentityRole>? _roleManager;
        static UserManager<IdentityUser>? _userManager;
        public static async Task EnsurePopulatedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                _context = scope.ServiceProvider.GetRequiredService<PXLPRO2023Shoppers02DbContext>();
                _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!_context.UserRoles.Any())
                {
                    IdentityRole admin = new IdentityRole()
                    {
                        Name = "Admin"
                    };

                    IdentityResult result1 = await _roleManager.CreateAsync(admin);
                    if (!result1.Succeeded)
                    {
                        throw new Exception(result1.Errors.First().Code);
                    }

                    IdentityRole client = new IdentityRole()
                    {
                        Name = "Client"
                    };
                    IdentityResult result2 = await _roleManager.CreateAsync(client);
                    if (!result2.Succeeded)
                    {
                        throw new Exception(result1.Errors.First().Code);
                    }
                    IdentityUser adminUser = new IdentityUser()
                    {
                        UserName = "admin@pxl.be",
                        Email = "admin@pxl.be"
                    };
                    IdentityResult resultUser1 = await _userManager.CreateAsync(adminUser, "Adm!n007");
                    if (!resultUser1.Succeeded)
                    {
                        throw new Exception(resultUser1.Errors.First().Code);
                    }
                    resultUser1 = await _userManager.AddToRoleAsync(adminUser, "Admin");
                    if (!resultUser1.Succeeded)
                    {
                        throw new Exception(resultUser1.Errors.First().Code);
                    }
                    IdentityUser clientUser = new IdentityUser()
                    {
                        UserName = "Client@pxl.be",
                        Email = "Client@pxl.be"
                    };
                    IdentityResult resultUser2 = await _userManager.CreateAsync(clientUser, "Cli3nt001!");
                    if (!resultUser2.Succeeded)
                    {
                        throw new Exception(resultUser1.Errors.First().Code);
                    }
                    resultUser2 = await _userManager.AddToRoleAsync(clientUser, "Client");
                    if (!resultUser2.Succeeded)
                    {
                        throw new Exception(resultUser1.Errors.First().Code);
                    }
                }
                if(!_context.ProductCategory.Any())
                {
                    foreach (var topic in CategorysOpvullen)
                    {
                        _context.ProductCategory.Add(topic);
                    }
                    _context.SaveChanges();
                }
                if (!_context.Product.Any())
                {
                    foreach (var topic in ProductOpvullen)
                    {
                        _context.Product.Add(topic);
                    }
                    _context.SaveChanges();
                }                
            }
        }
        public static List<ProductsCategories> CategorysOpvullen = new List<ProductsCategories>
        {
            new ProductsCategories
            {
                CategoryName = "Zetel",
                CategoryDescription = "Een zacht zitvlak voor thuis"
            },
            new ProductsCategories
            {
                CategoryName = "Stoel",
                CategoryDescription = "Een hard zitvlak voor thuis"
            },
        };

        public static List<Products> ProductOpvullen = new List<Products>
        {
            new Products
            {
                ProductName = "L Zetel",
                ProductDescription = "Een zetel voor in de woonkamer",
                ProductPrice = 50.50,
                Category = CategorysOpvullen[0]
            },
            new Products
            {
                ProductName = "XL Zetel",
                ProductDescription = "Een grote zetel voor in de woonkamer",
                ProductPrice = 105.99,
                Category = CategorysOpvullen[0]
            },
            new Products
            {
                ProductName = "XXL Zetel",
                ProductDescription = "Een extra grote zetel voor in de woonkamer",
                ProductPrice = 159.85,
                Category = CategorysOpvullen[0]
            },
            new Products
            {
                ProductName = "L Stoel",
                ProductDescription = "Een stoel voor in de woonkamer",
                ProductPrice = 25.50,
                Category = CategorysOpvullen[1]
            },
            new Products
            {
                ProductName = "XL Stoel",
                ProductDescription = "Een grote stoel voor in de woonkamer",
                ProductPrice = 50.25,
                Category = CategorysOpvullen[1]
            },
            new Products
            {
                ProductName = "XXL Stoel",
                ProductDescription = "Een extra grote stoel voor in de woonkamer",
                ProductPrice = 75.99,
                Category = CategorysOpvullen[1]
            }
            
            //var products = new Products[2];
            //products[0] = new Products
            //{
            //    ProductName = "XXL Zetel",
            //    ProductDescription = "Een extra grote zetel voor in de woonkamer",
            //    ProductPrice = 25.50,
            //};
            //products[1] = new Products
            //{
            //    ProductName = "Grote Stoel",
            //    ProductDescription = "Een grote stoel voor buiten in de tuin",
            //    ProductPrice = 15.50
            //};
            //products[2] = new Products
            //{
            //    ProductName = "Grote Stoel",
            //    ProductDescription = "Een grote stoel voor buiten in de tuin",
            //    ProductPrice = 15.50
            //};
            //products[3] = new Products
            //{
            //    ProductName = "Grote Stoel",
            //    ProductDescription = "Een grote stoel voor buiten in de tuin",
            //    ProductPrice = 15.50
            //};
            //products[4] = new Products
            //{
            //    ProductName = "Grote Stoel",
            //    ProductDescription = "Een grote stoel voor buiten in de tuin",
            //    ProductPrice = 15.50
            //};
            //products[5] = new Products
            //{
            //    ProductName = "Grote Stoel",
            //    ProductDescription = "Een grote stoel voor buiten in de tuin",
            //    ProductPrice = 15.50
            //};
            //return products;
        };
    }
}
