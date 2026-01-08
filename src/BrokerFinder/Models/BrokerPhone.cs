using System.ComponentModel.DataAnnotations;

namespace BrokerFinder.Models;

public class BrokerPhone
{
    public Guid Id { get; set; }
    [Required] public string Number { get; set; } = string.Empty;
    public string? Description { get; set; }

    public Guid BrokerId { get; set; }
    public Broker? Broker { get; set; }
}