using Domain.Interfaces.V1;

namespace Domain;

public class TableAudit : ITableAudit
{
    public DateTime Added { get; set; }
    public DateTime Modified { get; set; }
}