using System;
using System.Configuration;

using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;

namespace SampleSOA.PatientOrderService
{
    public class MigrationRunner
    {
        public void RunMigrations()
        {
            using (var announcer = new TextWriterAnnouncer(Console.Out)
                {
                    ShowElapsedTime = true,
                    ShowSql = true
                })
            {
                var assembly = typeof(MigrationRunner).Assembly.GetName().Name;

                var migrationContext = new RunnerContext(announcer)
                    {
                        Connection = ConfigurationManager.ConnectionStrings[0].ConnectionString,
                        Database = "SqlServer2008",
                        Target = assembly
                    };

                var executor = new TaskExecutor(migrationContext);
                executor.Execute();
            }
        }
    }
}