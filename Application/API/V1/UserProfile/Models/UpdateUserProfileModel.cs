using Common.Enums;

namespace Application.API.V1.UserProfile.Models;

public class UpdateUserProfileModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}