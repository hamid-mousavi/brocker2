using Microsoft.AspNetCore.Identity;

namespace BrokerFinder.Models;

public class ApplicationUser : IdentityUser
{
    // Link to Broker profile if this user is a broker
    public Guid? BrokerId { get; set; }
}