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
                CategoryName = "Chair",
                CategoryDescription = "Seat for 1 person"
            },
            new ProductsCategories
            {
                CategoryName = "Sofa",
                CategoryDescription = "Seat for multiple people"
            },
        };

        public static List<Products> ProductOpvullen = new List<Products>
        {
            new Products
            {
                ProductName = "Tsunami Chair",
                ProductDescription = "This chair is so strong it could withstand any calamity. Even after getting hit by a tsunami it stands still. We've lost the owner thou.",
                ProductPrice = 69.99,
                Category = CategorysOpvullen[0],
                ProductImage = "https://media.gettyimages.com/id/520307488/nl/foto/a-chair-thrown-into-mud-on-the-river-tees-in-middlesbrough-teeside-uk.jpg?s=612x612&w=0&k=20&c=wMfbT1XbOHyxUVwu4sSGzzFPX8CKmglJZ58j9BSxptU=",
                ProductStock = 420
            },
            new Products
            {
                ProductName = "The Croissant",
                ProductDescription = "This delicious looking chair isn't delicious at all. Made from the best asbestos by the best carpenters. This chair will bring cardogenics to your home.",
                ProductPrice = 105.99,
                Category = CategorysOpvullen[0],
                ProductImage = "https://cdn.shopify.com/s/files/1/0625/3651/5781/products/AlexaSofa10_800x.jpg?v=1670776692",
                ProductStock = 420
            },
            new Products
            {
                ProductName = "The hand",
                ProductDescription = "Ever wanted to be lifted by a giant hand? Well, you can't, but this is close enough. Specially made for people who like fingers up the butt",
                ProductPrice = 159.85,
                Category = CategorysOpvullen[0],
                ProductImage = "https://cdn1.vente-unique.com/thumbnails/product/107/107559/gallery_slider/xl/fauteuil_345499.webp",
                ProductStock = 420
            },
            new Products
            {
                ProductName = "Ne wolk pie",
                ProductDescription = "Stylish, cloudish, cheap and not weird at all. I think you're prefer 'The Hand'.",
                ProductPrice = 25.50,
                Category = CategorysOpvullen[0],
                ProductImage = "https://i.pinimg.com/474x/56/d0/47/56d04775f1d75c05ea288277d3e4daee--bean-bag-chairs-bean-chair.jpg",
                ProductStock = 420
            },
            new Products
            {
                ProductName = "Le cactus",
                ProductDescription = "Made for people that do not like people. Made from real cacti (which oddly is the plural for the genus cactus), this sofa will make sure guests know they aren't welcome.",
                ProductPrice = 150.25,
                Category = CategorysOpvullen[1],
                ProductImage = "https://lh6.ggpht.com/_hVfE2qcyzXU/TKeg2SEpcfI/AAAAAAAAAoQ/bAZ4Dy7bIcw/s800/sofa-designs-cactus.jpg",
                ProductStock = 420
            },
            new Products
            {
                ProductName = "Gains for real",
                ProductDescription = "You bulking bro? Raw eggs EVERYWHERE. Never you'll need to run to the fridge when you're catabolic. Crack one open en slurp it up!.",
                ProductPrice = 75.99,
                Category = CategorysOpvullen[1],
                ProductImage = "https://www.toxel.com/wp-content/uploads/2008/12/3ggsofa.jpg",
                ProductStock = 420
            },
            new Products
            {
                ProductName = "Normal sized half sofa",
                ProductDescription = "Do not be fooled. The picture isn't just half the sofa. It's the whole sofa. You pretty much get what you see.",
                ProductPrice = 50.25,
                Category = CategorysOpvullen[1],
                ProductImage = "https://static.dezeen.com/uploads/2020/11/nota-sofa-basta-furniture-dezeem-showroom_dezeen_2364_col_5.jpg",
                ProductStock = 420
            },
            new Products
            {
                ProductName = "Kami",
                ProductDescription = "Want to know how god feels? Buy this sofa and sit on top of the world. Feel better than Leonardi Di Caprio did after leaving that steaming hot car.",
                ProductPrice = 75.99,
                Category = CategorysOpvullen[1],
                ProductImage = "https://www.saltypeaks.com/wordpress/wp-content/uploads/2012/09/mountain-couch-sofa.jpg",
                ProductStock = 420
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
