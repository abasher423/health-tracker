using Common.Enums;

namespace HealthTracker.DTOs.UserProfile;

public class CreateUserProfileDto
{
    public Guid UserId { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}