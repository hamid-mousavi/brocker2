namespace BrokerFinder.Models;

public class BrokerPort
{
    public Guid BrokerId { get; set; }
    public Broker? Broker { get; set; }

    public Guid PortId { get; set; }
    public Port? Port { get; set; }
}