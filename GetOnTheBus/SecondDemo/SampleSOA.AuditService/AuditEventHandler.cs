using System;

using MassTransit;

using SampleSOA.Messages;

namespace SampleSOA.AuditService
{
    public class AuditEventHandler : Consumes<IAuditableEvent>.Context
    {
        public void Consume(IConsumeContext<IAuditableEvent> message)
        {
            IAuditableEvent auditEvent = message.Message;
            Console.WriteLine(
                "Audit - message from {0} by user {1} at {2}",
                message.SourceAddress,
                auditEvent.ByUserId,
                auditEvent.EventTime);
        }
    }
}