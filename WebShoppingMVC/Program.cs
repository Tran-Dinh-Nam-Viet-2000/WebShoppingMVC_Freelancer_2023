using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebShoppingMVC.Data.Context;
using WebShoppingMVC.Data.Repository.Interface;
using WebShoppingMVC.Data.Repository;
using WebShoppingMVC.Services;
using WebShoppingMVC.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options
								.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register service
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
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

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "MyArea",
    areaName: "Area",
    pattern: "Area/{controller}/{action}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
