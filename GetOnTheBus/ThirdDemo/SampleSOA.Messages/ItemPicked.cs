using System;

namespace SampleSOA.Messages
{
    [Serializable]
    public class ItemPicked : IAuditableEvent
    {
        public ItemPicked()
        {
            CorrelationId = Guid.NewGuid();
        }

        public string AtDeviceId { get; set; }

        public string ByUserId { get; set; }

        public Guid CorrelationId { get; set; }

        public DateTime EventTime { get; set; }

        public string ItemId { get; set; }

        public int Quantity { get; set; }
    }
}