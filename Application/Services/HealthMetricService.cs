using Application.Abstractions.Services;
using Application.API.V1.HealthMetric.Models;
using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.HealthMetrics;

namespace Application.Services;

public class HealthMetricService : IHealthMetricService
{
    private readonly IHealthMetricRepository _healthMetricRepository;
    private readonly IMapper _mapper;

    public HealthMetricService(IHealthMetricRepository healthMetricRepository, IMapper mapper)
    {
        _healthMetricRepository = healthMetricRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HealthMetricModel>> GetHealthDataEntries(CancellationToken cancellationToken)
    {
        var entries = await _healthMetricRepository.GetAllHealthDataEntries(cancellationToken);
        return _mapper.Map<IEnumerable<HealthMetricModel>>(entries);
    }

    public async Task<HealthMetricModel> GetHealthDataEntry(Guid id, CancellationToken cancellationToken)
    {
        var entry = await _healthMetricRepository.GetSingleHealthDataEntry(id, cancellationToken);
        return _mapper.Map<HealthMetricModel>(entry);
    }

    public async Task<HealthMetricModel> CreateHealthDataEntry(HealthMetricModel healthMetric, CancellationToken cancellationToken)
    {
        var entryToCreate = new HealthMetric(Guid.NewGuid(), healthMetric.Type, healthMetric.UnitOfMeasure);
        var createdEntry = await _healthMetricRepository.CreateHealthDataEntry(entryToCreate, cancellationToken);
        return _mapper.Map<HealthMetricModel>(createdEntry);
    }

    public async Task<HealthMetricModel> UpdateHealthDataEntry(HealthMetricModel healthMetric, CancellationToken cancellationToken)
    {
        var entryToUpdate = new HealthMetric(healthMetric.Id, healthMetric.Type, healthMetric.UnitOfMeasure);
        var updatedEntry = await _healthMetricRepository.UpdateHealthDataEntry(entryToUpdate, cancellationToken);
        return _mapper.Map<HealthMetricModel>(updatedEntry);
    }

    public async Task<bool> DeleteHealthDataEntry(Guid id, CancellationToken cancellationToken)
    {
        return await _healthMetricRepository.DeleteHealthDataEntry(id, cancellationToken);
    }
}