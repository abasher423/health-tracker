namespace Domain.Entities;

public class Progress : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid GoalId { get; set; }
    public decimal Value { get; set; }
    public User User { get; set; }
    public Goal Goal { get; set; }
}