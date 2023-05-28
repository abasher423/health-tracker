namespace Domain;

public class BaseEntity : TableAudit
{
    public Guid Id { get; set; }
}