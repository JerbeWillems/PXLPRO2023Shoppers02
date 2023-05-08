using Microsoft.AspNetCore.Identity;

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
            }
        }
    }
}
