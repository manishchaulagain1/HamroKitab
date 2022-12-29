using Microsoft.EntityFrameworkCore;
using HamroKitab.Data.Services;
using HamroKitab.Data;
using HamroKitab.Data.Cart;

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
builder.Services.AddSession();

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.MapDefaultControllerRoute();

app.UseStaticFiles();
app.UseSession();

//Seeding
HamroDbInitializer.Seed(app);

app.Run();