using System;
using System.Text;
using RabbitMQ.Client;

namespace SubscriberForLogging
{
    class Program
    {
        private const string ExchangeName = "WidgetOrderTopicExchange";

        private static void Main(string[] args)
        {
            Console.WriteLine("Logger waiting for messages...");

            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, "topic");

                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queueName, ExchangeName, "ewk.#");

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

                    int logEntry = 0;
                    Console.WriteLine("Waiting for work - press <ctrl-c> to shut down...");
                    while (true)
                    {
                        var message = consumer.Queue.Dequeue();

                        var body = message.Body;
                        var contents = Encoding.UTF8.GetString(body);

                        Console.WriteLine("[{0}:{1:yyyyMMdd-HHmmss.fffff}] {2}", 
                            logEntry++, DateTimeOffset.Now, contents);
                    }
                }
            }
        }
    }
}
