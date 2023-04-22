namespace Domain.Entities;

public class Progress : TableAudit
{
    public Guid Id { get; set; }

    public decimal Value { get; set; }

    public Goal Goal { get; set; }
}