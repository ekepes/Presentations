using MassTransit;

namespace SampleSOA.PatientOrderService
{
    public class PatientOrderService
    {
        private readonly IServiceBus _bus;

        private readonly ItemPickedHandler _handler;

        public PatientOrderService(IServiceBus bus, ItemPickedHandler handler)
        {
            _bus = bus;
            _handler = handler;
        }

        public void Start()
        {
            _bus.SubscribeInstance(_handler);
            _bus.WriteIntrospectionToConsole();
        }

        public void Stop()
        {
            _bus.Dispose();
        }
    }
}