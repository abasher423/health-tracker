using Common.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Persistence.Repositories.HealthDataEntries;

public class HealthDataEntryRepository : IHealthDataEntryRepository
{
    private readonly HealthTrackerDbContext _context;

    public HealthDataEntryRepository(HealthTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HealthDataEntry>> GetAllHealthDataEntries(CancellationToken cancellationToken)
    {
        var entries = await _context.HealthDataEntries.ToListAsync(cancellationToken);
        return entries;
    }

    public async Task<HealthDataEntry> GetSingleHealthDataEntry(Guid id, CancellationToken cancellationToken)
    {
        var entry = await _context.HealthDataEntries
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entry == null)
        {
            throw new HealthDataEntryArgumentException("Please provide a valid Health Data Entry ID");
        }

        return entry;
    }

    public async Task<HealthDataEntry> CreateHealthDataEntry(HealthDataEntry healthDataEntry, CancellationToken cancellationToken)
    {
        var entryToBeCreated = new HealthDataEntry()
        {
            Id = Guid.NewGuid(),
            UserId = healthDataEntry.UserId,
            HealthMetricId = healthDataEntry.HealthMetricId,
            Name = healthDataEntry.Name,
            Value = healthDataEntry.Value
        };

        await _context.HealthDataEntries.AddAsync(entryToBeCreated, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entryToBeCreated;
    }

    public async Task<HealthDataEntry> UpdateHealthDataEntry(HealthDataEntry healthDataEntry, CancellationToken cancellationToken)
    {
        var entry = await _context.HealthDataEntries
            .FirstOrDefaultAsync(x => x.Id == healthDataEntry.Id, cancellationToken);

        if (entry == null)
        {
            throw new HealthDataEntryArgumentException("The Health Data Entry record to update does not exist.");
        }

        if (!string.IsNullOrEmpty(healthDataEntry.UserId.ToString()))
        {
            entry.UserId = healthDataEntry.UserId;
        }

        if (!string.IsNullOrEmpty(healthDataEntry.HealthMetricId.ToString()))
        {
            entry.HealthMetricId = healthDataEntry.HealthMetricId;
        }

        if (!string.IsNullOrEmpty(healthDataEntry.Name.ToString()))
        {
            entry.Name = healthDataEntry.Name;
        }

        if (!string.IsNullOrEmpty(healthDataEntry.Value.ToString()))
        {
            entry.Value = healthDataEntry.Value;
        }
        
        _context.Entry(entry).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);

        return entry;
    }

    public async Task<bool> DeleteHealthDataEntry(Guid id, CancellationToken cancellationToken)
    {
        var entry = await _context.HealthDataEntries
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entry == null)
        {
            throw new HealthDataEntryArgumentException("The Health Data Entry record to update does not exist.");
        }
        
        _context.HealthDataEntries.Remove(entry);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}