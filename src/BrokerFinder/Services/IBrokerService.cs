using BrokerFinder.DTOs;

namespace BrokerFinder.Services;

public interface IBrokerService
{
    Task<(IEnumerable<BrokerDto> Brokers, int TotalPages)> SearchAsync(string? port, string? specialty, int page = 1, int pageSize = 12);
    Task<BrokerDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<CredentialDto>> GetCredentialsAsync(Guid brokerId);
    Task LogContactAsync(Guid brokerId, string contactEmail, string? message);
}