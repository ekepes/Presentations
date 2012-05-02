using MassTransit;

using Ninject.Modules;

namespace SampleSOA.AuditService
{
    public class AuditServiceRegistry :
        NinjectModule
    {
        public override void Load()
        {
            Bind<AuditEventHandler>().ToSelf();

            Bind<AuditService>()
                .To<AuditService>()
                .InSingletonScope();

            Bind<IServiceBus>().ToMethod(context => ServiceBusFactory.New(sbc =>
                {
                    sbc.UseRabbitMqRouting();
                    sbc.ReceiveFrom("rabbitmq://localhost/audit_service");

                    //sbc.UseControlBus();
                }))
                .InSingletonScope();
        }
    }
}