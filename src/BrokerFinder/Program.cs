using BrokerFinder.Data;
using BrokerFinder.Models;
using BrokerFinder.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var connection = builder.Configuration.GetConnectionString("DefaultConnection") ??
                 Environment.GetEnvironmentVariable("CONN_STR") ??
                 "Host=postgres;Database=brokerdb;Username=postgres;Password=postgres";

// Add services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connection));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

// App services
builder.Services.AddScoped<IBrokerService, BrokerService>();

var app = builder.Build();

// Run migrations and seed (only in dev / if env var set)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    try
    {
        db.Database.Migrate();
    }
    catch
    {
        // If migrations are not present (development), ensure database is created
        db.Database.EnsureCreated();
    }
    await DataSeeder.SeedAsync(db, userManager, roleManager);
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();