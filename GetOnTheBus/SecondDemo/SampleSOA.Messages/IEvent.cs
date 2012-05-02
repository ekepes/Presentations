using System;

namespace SampleSOA.Messages
{
    public interface IEvent
    {
        DateTime EventTime { get; }
    }
}