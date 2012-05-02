using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using log4net.Config;

using Ninject;

using Topshelf;

namespace SampleSOA.AuditService
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo("auditService.log4net.xml"));

            HostFactory.Run(
                c =>
                {
                    c.SetServiceName("SampleSOAAuditService");
                    c.SetDisplayName("Sample SOA Audit Service");
                    c.SetDescription("A sample SOA service for tracking auditable events.");

                    c.RunAsLocalSystem();
                    c.DependsOnMsmq();

                    StandardKernel kernel = new StandardKernel();
                    AuditServiceRegistry module = new AuditServiceRegistry();
                    kernel.Load(module);

                    c.Service<AuditService>(
                        s =>
                        {
                            s.ConstructUsing(builder => kernel.Get<AuditService>());
                            s.WhenStarted(o => o.Start());
                            s.WhenStopped(o => o.Stop());
                        });
                });
        }
    }
}
