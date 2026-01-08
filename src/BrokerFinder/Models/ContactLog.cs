namespace BrokerFinder.Models;

public class ContactLog
{
    public Guid Id { get; set; }
    public Guid BrokerId { get; set; }
    public Broker? Broker { get; set; }
    public string ContactEmail { get; set; } = string.Empty;
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}