using System;

using PetaPoco;

using SampleSOA.Messages;

namespace SampleSOA.PatientOrderService
{
    public class ItemPickedHandler : TransactionalMessageHandler<ItemPicked>
    {
        private static readonly Random Random = new Random();

        protected override void Consume(ItemPicked message, 
            Database database)
        {
            database.Insert("ItemPick", "ItemPickId", message);
            if (Random.Next(3) > 0)
            {
                Console.WriteLine(
                    "[{0}] {1} Picked {2} units of item#{3} at {4} by {5}.",
                    message.CorrelationId,
                    message.EventTime,
                    message.Quantity,
                    message.ItemId,
                    message.AtDeviceId,
                    message.ByUserId);
            }
            else
            {
                Console.WriteLine("Failing message {0}",
                    message.CorrelationId);
                throw new ArithmeticException("blah blah blah");
            }
        }
    }
}