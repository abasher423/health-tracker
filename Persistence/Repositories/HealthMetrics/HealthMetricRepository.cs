using Common.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations.Context;

namespace Persistence.Repositories.HealthMetrics;

public class HealthMetricRepository : IHealthMetricRepository
{
    private readonly HealthTrackerDbContext _context;

    public HealthMetricRepository(HealthTrackerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HealthMetric>> GetAllHealthDataEntries(CancellationToken cancellationToken)
    {
        return await _context.HealthMetrics.ToListAsync(cancellationToken);
    }

    public async Task<HealthMetric> GetSingleHealthDataEntry(Guid id, CancellationToken cancellationToken)
    {
        var entry = await _context.HealthMetrics.FirstOrDefaultAsync(x => x.Id == id,
            cancellationToken);

        if (entry == null)
        {
            throw new HealthMetricArgumentException("Please provide a valid Health Metric ID");
        }

        return entry;
    }

    public async Task<HealthMetric> CreateHealthDataEntry(HealthMetric healthMetric, CancellationToken cancellationToken)
    {
        var entryToBeCreated = new HealthMetric(healthMetric.Id, healthMetric.Type, healthMetric.UnitOfMeasurement);

        await _context.HealthMetrics.AddAsync(entryToBeCreated, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entryToBeCreated;

    }

    public async Task<HealthMetric> UpdateHealthDataEntry(HealthMetric healthMetric, CancellationToken cancellationToken)
    {
        var entry =
            await _context.HealthMetrics.FirstOrDefaultAsync(x => x.Id == healthMetric.Id, 
                cancellationToken);

        if (!string.IsNullOrEmpty(healthMetric.Id.ToString()))
        {
            entry.Id = healthMetric.Id;
        }

        if (!string.IsNullOrEmpty(healthMetric.Type.ToString()))
        {
            entry.Type = healthMetric.Type;
        }

        if (!string.IsNullOrEmpty(healthMetric.UnitOfMeasurement))
        {
            entry.UnitOfMeasurement = healthMetric.UnitOfMeasurement;
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
            throw new HealthDataEntryArgumentException("The Health Metric record to update does not exist.");
        }
        
        _context.HealthDataEntries.Remove(entry);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}