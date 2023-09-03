using Application.Abstractions.Messaging;
using Application.API.V1.HealthDataEntry.Models;

namespace Application.API.V1.HealthDataEntry.Queries;

public class GetHealthDataEntryQuery : IQuery<HealthDataEntryModel>
{
    public Guid Id { get; set; }

    public GetHealthDataEntryQuery(Guid id)
    {
        Id = id;
    }
}