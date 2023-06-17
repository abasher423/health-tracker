namespace Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserProfile UserProfile { get; set; }
    public ICollection<HealthDataEntry> HealthDataEntries { get; set; }
    public ICollection<Goal> Goals { get; set; }
    public ICollection<Progress> Progresses { get; set; }
}