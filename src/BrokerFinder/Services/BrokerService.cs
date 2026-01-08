using BrokerFinder.Data;
using BrokerFinder.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BrokerFinder.Services;

public class BrokerService : IBrokerService
{
    private readonly ApplicationDbContext _db;

    public BrokerService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<(IEnumerable<BrokerDto> Brokers, int TotalPages)> SearchAsync(string? port, string? specialty, int page = 1, int pageSize = 12)
    {
        var q = _db.Brokers.AsQueryable().Where(b => b.ProfileStatus == Models.ProfileStatus.Approved);

        if (!string.IsNullOrWhiteSpace(port))
        {
            q = q.Where(b => b.BrokerPorts.Any(bp => bp.Port!.Name.Contains(port)));
        }

        if (!string.IsNullOrWhiteSpace(specialty))
        {
            q = q.Where(b => b.Specialties.Any(s => s.Specialty.ToString() == specialty));
        }

        var total = await q.CountAsync();
        var totalPages = (int)Math.Ceiling(total / (double)pageSize);

        var list = await q
            .OrderByDescending(b => b.ViewsCount)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new BrokerDto(b.Id, b.FullName, b.Email, b.CompanyName, b.YearsOfExperience, b.Description, b.Latitude, b.Longitude))
            .ToListAsync();

        return (list, totalPages);
    }

    public async Task<BrokerDto?> GetByIdAsync(Guid id)
    {
        var b = await _db.Brokers.FindAsync(id);
        if (b == null) return null;
        return new BrokerDto(b.Id, b.FullName, b.Email, b.CompanyName, b.YearsOfExperience, b.Description, b.Latitude, b.Longitude);
    }

    public async Task<IEnumerable<CredentialDto>> GetCredentialsAsync(Guid brokerId)
    {
        return await _db.Credentials
            .Where(c => c.BrokerId == brokerId)
            .Select(c => new CredentialDto(c.Id, c.Title, c.Description, c.IssuerOrCompanyName, c.IssueDate, c.ExpireDate, c.FilePath))
            .ToListAsync();
    }

    public async Task LogContactAsync(Guid brokerId, string contactEmail, string? message)
    {
        var log = new Models.ContactLog
        {
            Id = Guid.NewGuid(),
            BrokerId = brokerId,
            ContactEmail = contactEmail,
            Message = message,
            CreatedAt = DateTime.UtcNow
        };
        _db.ContactLogs.Add(log);
        await _db.SaveChangesAsync();
    }
}