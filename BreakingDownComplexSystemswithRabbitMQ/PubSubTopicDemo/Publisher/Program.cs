using System;
using System.Text;
using RabbitMQ.Client;

namespace Publisher
{
    class Program
    {
        private const string ExchangeName = "WidgetOrderTopicExchange";
        private const string RoutingKeyForOtherWorkMessages = "ewk.otherwork.workitem";
        private const string RoutingKeyForPurchaseMessages = "ewk.purchasing.order";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, "topic");
                    int quantity = 1;

                    while (true)
                    {
                        Console.WriteLine("Ready to publish - press <enter> to publish an order ('o' for other work, 'x' to exit)...");
                        var input = Console.ReadLine();
                        if (input.Trim().ToLower() == "x")
                        {
                            break;
                        }
                        else if (input.Trim().ToLower() == "o")
                        {
                            var body = Encoding.UTF8.GetBytes("Do other work!");

                            channel.BasicPublish(ExchangeName, RoutingKeyForOtherWorkMessages, null, body);
                        }
                        else
                        {
                            var message = string.Format("{0} widgets ordered.", quantity++);
                            var body = Encoding.UTF8.GetBytes(message);

                            channel.BasicPublish(ExchangeName, RoutingKeyForPurchaseMessages, null, body);
                        }
                    }
                }
            }
        }
    }
}
