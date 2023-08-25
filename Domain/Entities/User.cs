using Common.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string EmailVerificationToken { get; set; }
    public DateTime EmailVerificationTokenExpiration { get; set; }
    public TokenStatus EmailTokenStatus { get; set; }
    public string HashedPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserProfile UserProfile { get; set; }
    public ICollection<HealthDataEntry> HealthDataEntries { get; set; }
    public ICollection<Goal> Goals { get; set; }
    public ICollection<Progress> Progresses { get; set; }
}