using System.ComponentModel.DataAnnotations;

namespace BrokerFinder.Models;

public enum CredentialType { Certificate, License, WorkExperience }

public class Credential
{
    public Guid Id { get; set; }
    [Required] public string Title { get; set; } = string.Empty;
    public CredentialType CredentialType { get; set; }
    public string? Description { get; set; }
    public string? FilePath { get; set; }
    public string? IssuerOrCompanyName { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpireDate { get; set; }

    public Guid BrokerId { get; set; }
    public Broker? Broker { get; set; }
}