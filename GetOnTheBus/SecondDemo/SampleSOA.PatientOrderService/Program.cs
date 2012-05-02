using System.IO;

using log4net.Config;

using Ninject;

using Topshelf;

namespace SampleSOA.PatientOrderService
{
    public class Program
    {
        private static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo("patientOrderService.log4net.xml"));

            HostFactory.Run(
                c =>
                    {
                        c.SetServiceName("SampleSOAPatientOrderService");
                        c.SetDisplayName("Sample SOA Patient Order Service");
                        c.SetDescription("A sample SOA service for handling Patient Orders.");

                        c.RunAsLocalSystem();
                        c.DependsOnMsmq();

                        StandardKernel kernel = new StandardKernel();
                        PatientOrderServiceRegistry module = new PatientOrderServiceRegistry();
                        kernel.Load(module);

                        c.Service<PatientOrderService>(
                            s =>
                                {
                                    s.ConstructUsing(builder => kernel.Get<PatientOrderService>());
                                    s.WhenStarted(o => o.Start());
                                    s.WhenStopped(o => o.Stop());
                                });
                    });
        }
    }
}