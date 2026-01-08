using System.ComponentModel.DataAnnotations;

namespace BrokerFinder.Models;

public enum BrokerType { Individual, Company }
public enum ProfileStatus { Pending, Approved, Rejected, Suspended }

public class Broker
{
    public Guid Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    public BrokerType BrokerType { get; set; }

    public string? CompanyName { get; set; }
    public string? CompanyRegistrationNumber { get; set; }

    public int YearsOfExperience { get; set; }

    public string? Description { get; set; }
    public string? ProfileImagePath { get; set; }

    public ProfileStatus ProfileStatus { get; set; } = ProfileStatus.Pending;

    // relations
    public Address? Address { get; set; }
    public ICollection<BrokerPhone> Phones { get; set; } = new List<BrokerPhone>();
    public ICollection<BrokerPort> BrokerPorts { get; set; } = new List<BrokerPort>();
    public ICollection<Credential> Credentials { get; set; } = new List<Credential>();
    public ICollection<BrokerSpecialty> Specialties { get; set; } = new List<BrokerSpecialty>();
    public int ViewsCount { get; set; }
    public int ContactAttempts { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}