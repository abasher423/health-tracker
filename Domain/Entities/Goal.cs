namespace Domain.Entities;

public class Goal : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public decimal Target { get; set; }
    public User User { get; set; }
    public ICollection<Progress> Progresses { get; set; }

}