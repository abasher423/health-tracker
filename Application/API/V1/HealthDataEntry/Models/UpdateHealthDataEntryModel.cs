using Common.Enums;

namespace Application.API.V1.HealthDataEntry.Models;

public class UpdateHealthDataEntryModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public HealthDataName Name { get; set; }
    public decimal Value { get; set; }
}