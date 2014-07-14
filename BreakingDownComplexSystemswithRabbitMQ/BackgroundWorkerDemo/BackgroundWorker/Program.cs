using System;
using System.Text;
using RabbitMQ.Client;

namespace BackgroundWorker
{
    class Program
    {
        private const string QueueName = "WidgetOrders";

        private static void Main()
        {
            Console.WriteLine("Ready to start shipping orders - press <enter> to pump them out...");
            Console.ReadLine();

            var factory = new ConnectionFactory {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(QueueName, false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(QueueName, true, consumer);

                    Console.WriteLine("Waiting for work - press <ctrl-c> to shut down...");
                    while (true)
                    {
                        var message = consumer.Queue.Dequeue();

                        var body = message.Body;
                        var contents = Encoding.UTF8.GetString(body);

                        int quantity = int.Parse(contents.Split(' ')[0]);
                        Console.WriteLine("Shipping {0} widgets.", quantity);
                    }
                }
            }
        }
    }
}
