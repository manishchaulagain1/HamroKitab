using Microsoft.EntityFrameworkCore;
using HamroKitab.Data.Services;
using HamroKitab.Data;
using HamroKitab.Data.Cart;
using HamroKitab.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HamroDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HamroDbContext") ?? throw new InvalidOperationException("Connection string 'HamroKitabContext' not found.")));

//Services configuration
builder.Services.AddScoped<IPublisherService, PublisherService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBooksService, BooksService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<HamroDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.MapDefaultControllerRoute();

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

//Seeding
HamroDbInitializer.Seed(app);
HamroDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();