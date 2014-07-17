using System;
using System.Text;
using RabbitMQ.Client;

namespace Publisher
{
    class Program
    {
        private const string ExchangeName = "WidgetOrderExchange";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, "fanout");
                    int quantity = 1;

                    while (true)
                    {
                        Console.WriteLine("Ready to publish - press <enter> to publish an order ('x' to exit)...");
                        var input = Console.ReadLine();
                        if (input.Trim().ToLower() == "x")
                        {
                            break;
                        }

                        var message = string.Format("{0} widgets ordered.", quantity++);
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(ExchangeName, "", null, body);
                    }
                }
            }
        }
    }
}
