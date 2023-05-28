using Common.Enums;

namespace Domain.Entities;

public class UserProfile : BaseEntity
{
    public Guid UserId { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public User User { get; set; }
}