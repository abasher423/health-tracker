namespace Domain;

public class TableAudit : ITableAudit
{
    public DateTime CreatedAtUtc { get; set; }
    
    public DateTime ModifiedAtUtc { get; set; }
}