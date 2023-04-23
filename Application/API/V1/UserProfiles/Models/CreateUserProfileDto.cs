using Common.Enums;

namespace Application.API.V1.UserProfiles.Models;

public class CreateUserProfileDto
{
    public Guid Id { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
}