using BrokerFinder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrokerFinder.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Broker> Brokers => Set<Broker>();
    public DbSet<BrokerPhone> BrokerPhones => Set<BrokerPhone>();
    public DbSet<Port> Ports => Set<Port>();
    public DbSet<BrokerPort> BrokerPorts => Set<BrokerPort>();
    public DbSet<Credential> Credentials => Set<Credential>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<BrokerSpecialty> BrokerSpecialties => Set<BrokerSpecialty>();
    public DbSet<ContactLog> ContactLogs => Set<ContactLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<BrokerPort>().HasKey(bp => new { bp.BrokerId, bp.PortId });

        // Seed some ports
        builder.Entity<Port>().HasData(
            new Port { Id = Guid.NewGuid(), Name = "Port of Tehran" },
            new Port { Id = Guid.NewGuid(), Name = "Port of Bandar Abbas" }
        );
    }
}