using Common.Enums;

namespace HealthTracker.DTOs.HealthDataEntry;

public class HealthDataEntryDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public HealthDataName Name { get; set; }
    public decimal Value { get; set; }
}