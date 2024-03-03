using Domain.Interfaces.V1;
using MediatR;

namespace Domain;

public class BaseEntity : TableAudit
{
    public Guid Id { get; set; }

    private List<INotification> _domainEvents;
    private List<INotification> DomainEvents => _domainEvents;

    public void AddDomainEvent(INotification domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(INotification domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}