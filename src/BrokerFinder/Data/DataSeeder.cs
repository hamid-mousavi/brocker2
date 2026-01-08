using BrokerFinder.Models;
using Microsoft.AspNetCore.Identity;

namespace BrokerFinder.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Roles
        var roles = new[] { "Admin", "Broker" };
        foreach (var r in roles)
        {
            if (!await roleManager.RoleExistsAsync(r))
                await roleManager.CreateAsync(new IdentityRole(r));
        }

        // Admin user
        var adminEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL") ?? "admin@example.com";
        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin == null)
        {
            admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
            await userManager.CreateAsync(admin, Environment.GetEnvironmentVariable("ADMIN_PWD") ?? "Admin123!");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        // Example broker
        if (!db.Brokers.Any())
        {
            var broker = new Broker
            {
                Id = Guid.NewGuid(),
                FullName = "Ali Reza",
                Email = "ali@broker.example",
                BrokerType = BrokerType.Individual,
                YearsOfExperience = 8,
                Description = "Experienced customs broker",
                ProfileStatus = ProfileStatus.Approved
            };
            db.Brokers.Add(broker);
            db.BrokerPhones.Add(new BrokerPhone { Id = Guid.NewGuid(), Broker = broker, Number = "+98-21-555-1234" });
            await db.SaveChangesAsync();
        }
    }
}