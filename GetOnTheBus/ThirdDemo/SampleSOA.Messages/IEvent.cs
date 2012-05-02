using System;

using MassTransit;

namespace SampleSOA.Messages
{
    public interface IEvent : CorrelatedBy<Guid>
    {
        DateTime EventTime { get; }
    }
}