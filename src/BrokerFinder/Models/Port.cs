namespace BrokerFinder.Models;

public class Port
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<BrokerPort> BrokerPorts { get; set; } = new List<BrokerPort>();
}