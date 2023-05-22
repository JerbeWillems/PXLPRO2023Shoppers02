using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PXLPRO2023Shoppers02.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("PXLPRO2023Shoppers02DbConn");
builder.Services.AddDbContext<PXLPRO2023Shoppers02DbContext>(options =>
{
	options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<PXLPRO2023Shoppers02DbContext>();

// is dit nodig voor facebook ??
builder.Services.Configure<IdentityOptions>(options =>
options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ "
);

builder.Services.AddAuthentication().AddFacebook(fbOpt =>
{
	fbOpt.AppId = "A3527016080855407";
	fbOpt.AppSecret = "3868fda2281bcffa0f25794b5e90f410";
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulatedAsync(app);

app.Run();
