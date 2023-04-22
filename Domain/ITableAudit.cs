namespace Domain;

public interface ITableAudit
{
    public DateTime CreatedAtUtc { get; set; }
    
    public DateTime ModifiedAtUtc { get; set; }
}