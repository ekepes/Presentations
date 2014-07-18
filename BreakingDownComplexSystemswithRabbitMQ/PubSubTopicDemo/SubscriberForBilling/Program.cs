using System;
using System.Text;
using RabbitMQ.Client;

namespace SubscriberForBilling
{
    class Program
    {
        private const string ExchangeName = "WidgetOrderTopicExchange";

        private static void Main(string[] args)
        {
            Console.WriteLine("Billing ready for messages...");

            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, "topic");

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queueName, ExchangeName, "ewk.purchasing.order");

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

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
