namespace Domain.Interfaces.V1;

public interface ITableAudit
{
     DateTime Added { get; set; }
     DateTime Modified { get; set; }
}