namespace Domain;

public interface ITableAudit
{
     DateTime Added { get; set; }
     DateTime Modified { get; set; }
}