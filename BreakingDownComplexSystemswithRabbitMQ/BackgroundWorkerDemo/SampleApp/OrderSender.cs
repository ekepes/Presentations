using System;
using System.Text;
using RabbitMQ.Client;

namespace SampleApp
{
    public class OrderSender : IDisposable
    {
        private const string QueueName = "WidgetOrders";

        private readonly ConnectionFactory _factory = new ConnectionFactory() { HostName = "localhost" };
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public OrderSender()
        {
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(QueueName, false, false, false, null);
        }

        public void SendOrder(int quantity)
        {
            var message = string.Format("{0} widgets ordered.", quantity);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish("", QueueName, null, body);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }
    }
}