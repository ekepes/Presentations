using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace BackgroundWorker
{
    public class BackgroundWorker
    {
        private const string QueueName = "MultiWidgetOrders";

        public void DoWork()
        {
            Console.WriteLine("Ready to start shipping orders!");

            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(QueueName, true, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);

                    // Only take one message off of the queue at a time:
                    channel.BasicQos(0, 1, false);

                    // We need to acknowledge that we finished the work
                    channel.BasicConsume(QueueName, false, consumer);

                    Console.WriteLine("Waiting for work - press <ctrl-c> to shut down...");
                    while (true)
                    {
                        var message = consumer.Queue.Dequeue();

                        var body = message.Body;
                        var contents = Encoding.UTF8.GetString(body);

                        int quantity = int.Parse(contents.Split(' ')[0]);
                        Console.WriteLine("Shipping {0} widgets.", quantity);
                        
                        Thread.Sleep(quantity * 100);
                        Console.WriteLine("Shipped.");

                        channel.BasicAck(message.DeliveryTag, false);
                    }
                }
            }
        }
    }
}