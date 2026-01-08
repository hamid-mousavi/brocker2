namespace BrokerFinder.DTOs;

public record CredentialDto(Guid Id, string Title, string? Description, string? IssuerOrCompanyName, DateTime? IssueDate, DateTime? ExpireDate, string? FilePath);