namespace SampleSOA.Messages
{
    public interface IAuditableEvent : IEvent
    {
        string ByUserId { get; }
    }
}