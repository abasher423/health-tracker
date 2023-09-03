using Application.Abstractions.Messaging;
using Application.API.V1.HealthDataEntry.Models;

namespace Application.API.V1.HealthDataEntry.Queries;

public class ListHealthDataEntriesQuery : IQuery<IEnumerable<HealthDataEntryModel>>
{
}