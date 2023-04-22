namespace Domain.Entities;

public class Goal : TableAudit
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Target { get; set; }
    
    public HealthDataEntry HealthDataEntry { get; set; }
    
    public ICollection<Progress> Progresses { get; set; }
}