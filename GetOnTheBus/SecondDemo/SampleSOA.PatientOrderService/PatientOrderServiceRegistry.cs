using MassTransit;

using Ninject.Modules;

namespace SampleSOA.PatientOrderService
{
    public class PatientOrderServiceRegistry :
        NinjectModule
    {
        public override void Load()
        {
            Bind<ItemPickedHandler>().ToSelf();

            Bind<PatientOrderService>()
                .To<PatientOrderService>()
                .InSingletonScope();

            Bind<IServiceBus>().ToMethod(context => ServiceBusFactory.New(sbc =>
                {
                    sbc.UseRabbitMqRouting();
                    sbc.ReceiveFrom("rabbitmq://localhost/patient_order_service");
                }))
                .InSingletonScope();
        }
    }
}