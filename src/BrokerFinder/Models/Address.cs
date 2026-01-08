namespace BrokerFinder.Models;

public class Address
{
    public Guid Id { get; set; }
    public string? Line1 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }

    public Guid BrokerId { get; set; }
    public Broker? Broker { get; set; }
}