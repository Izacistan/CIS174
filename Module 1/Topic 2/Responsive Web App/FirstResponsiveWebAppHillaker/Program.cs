var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// AddControllersWithViews(), adds the services necessary to support an MVC app. Available with ASP.NET Core 3.0 and later.
builder.Services.AddControllersWithViews();

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

// Selects the endpoint for the route if one is found
app.UseRouting();

app.UseAuthorization();

// Controller Attribute
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

// Satic
app.MapControllerRoute(
    name: "static",
    pattern: "{controller=Home}/{action}/Page/{num}");

// Adds endpoints for controller actions and specifies a route (DEFAULT)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
