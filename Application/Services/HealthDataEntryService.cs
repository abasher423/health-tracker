using Application.Abstractions.Services;
using Application.API.V1.HealthDataEntry.Models;
using AutoMapper;
using Domain.Entities;
using Persistence.Repositories.HealthDataEntries;

namespace Application.Services;

public class HealthDataEntryService : IHealthDataEntryService
{
    private readonly IHealthDataEntryRepository _healthDataEntryRepository;
    private readonly IMapper _mapper;

    public HealthDataEntryService(IHealthDataEntryRepository healthDataEntryRepository, IMapper mapper)
    {
        _healthDataEntryRepository = healthDataEntryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HealthDataEntryModel>> GetHealthDataEntries(CancellationToken cancellationToken)
    {
        var entries = await _healthDataEntryRepository.GetAllHealthDataEntries(cancellationToken);
        return _mapper.Map<IEnumerable<HealthDataEntryModel>>(entries);
    }

    public async Task<HealthDataEntryModel> GetHealthDataEntry(Guid id, CancellationToken cancellationToken)
    {
        var entry = await _healthDataEntryRepository.GetSingleHealthDataEntry(id, cancellationToken);
        return _mapper.Map<HealthDataEntryModel>(entry);
    }

    public async Task<HealthDataEntryModel> CreateHealthDataEntry(HealthDataEntryModel healthDataEntry, CancellationToken cancellationToken)
    {
        var entryToCreate = new HealthDataEntry()
        {
            Id = Guid.NewGuid(),
            UserId = healthDataEntry.UserId,
            Name = healthDataEntry.Name,
            Value = healthDataEntry.Value
        };

        var createdEntry = await _healthDataEntryRepository.CreateHealthDataEntry(entryToCreate, cancellationToken);

        return _mapper.Map<HealthDataEntryModel>(createdEntry);
    }

    public async Task<HealthDataEntryModel> UpdateHealthDataEntry(HealthDataEntryModel healthDataEntry, CancellationToken cancellationToken)
    {
        var entryToUpdate = new HealthDataEntry()
        {
            Id = healthDataEntry.Id,
            UserId = healthDataEntry.UserId,
            Name = healthDataEntry.Name,
            Value = healthDataEntry.Value
        };

        var updatedEntry = await _healthDataEntryRepository.UpdateHealthDataEntry(entryToUpdate, cancellationToken);
        return _mapper.Map<HealthDataEntryModel>(updatedEntry);
    }

    public async Task<bool> DeleteHealthDataEntry(Guid id, CancellationToken cancellationToken)
    {
        return await _healthDataEntryRepository.DeleteHealthDataEntry(id, cancellationToken);
    }
}