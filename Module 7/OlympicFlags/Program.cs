using Microsoft.EntityFrameworkCore;
using OlympicFlags.Models;

var builder = WebApplication.CreateBuilder(args);

// must be called before AddControlWithViews()
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DI
builder.Services.AddDbContext<CountryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CountryContext")));

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "custom",
    pattern: "{controller=Home}/{action=Index}/cate/{activeCategory}/game/{activeGame}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
