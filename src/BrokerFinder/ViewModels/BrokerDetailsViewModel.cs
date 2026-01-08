using BrokerFinder.DTOs;

namespace BrokerFinder.ViewModels;

public class BrokerDetailsViewModel
{
    public BrokerDto Broker { get; set; } = default!;
    public IEnumerable<CredentialDto> Credentials { get; set; } = Enumerable.Empty<CredentialDto>();
}