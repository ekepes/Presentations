using System;

using MassTransit;

using SampleSOA.Messages;

namespace SampleSOA.PatientOrderService
{
    public class ItemPickedHandler : Consumes<ItemPicked>.All
    {
        public void Consume(ItemPicked message)
        {
            Console.WriteLine(
                "{0} Picked {1} units of item#{2} at {3} by {4}.",
                message.EventTime,
                message.Quantity,
                message.ItemId,
                message.AtDeviceId,
                message.ByUserId);
        }
    }
}