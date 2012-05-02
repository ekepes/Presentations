using MassTransit;

namespace SampleSOA.AuditService
{
    public class AuditService
    {
        private readonly IServiceBus _bus;

        private readonly AuditEventHandler _handler;

        public AuditService(IServiceBus bus, AuditEventHandler handler)
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