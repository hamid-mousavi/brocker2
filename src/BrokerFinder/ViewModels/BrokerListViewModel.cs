using BrokerFinder.DTOs;

namespace BrokerFinder.ViewModels;

public class BrokerListViewModel
{
    public IEnumerable<BrokerDto> Brokers { get; set; } = Enumerable.Empty<BrokerDto>();
    public int Page { get; set; } = 1;
    public int TotalPages { get; set; } = 1;
}