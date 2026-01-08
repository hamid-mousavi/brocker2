namespace BrokerFinder.Models;

public enum SpecialtyType { Import, Export, Transit }

public class BrokerSpecialty
{
    public Guid Id { get; set; }
    public SpecialtyType Specialty { get; set; }
    public Guid BrokerId { get; set; }
    public Broker? Broker { get; set; }
}