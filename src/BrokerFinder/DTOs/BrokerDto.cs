namespace BrokerFinder.DTOs;

public record BrokerDto(
    Guid Id,
    string FullName,
    string Email,
    string? CompanyName,
    int YearsOfExperience,
    string? Description,
    double? Latitude,
    double? Longitude
);