using Common.Enums;

namespace Application.API.V1.HealthDataEntry.Models;

public class UpdateHealthDataEntryModel
{
    public Guid UserId { get; set; }
    public Guid HealthMetricId { get; set; }
    public HealthDataName Name { get; set; }
    public decimal Value { get; set; }
}