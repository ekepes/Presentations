using System;
using System.Text;
using RabbitMQ.Client;

namespace SampleApp
{
    public class OrderSender : IDisposable
    {
        private const string QueueName = "MultiWidgetOrders";

        private readonly ConnectionFactory _factory = new ConnectionFactory() { HostName = "localhost" };
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public OrderSender()
        {
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(QueueName, true, false, false, null);
        }

        public void SendBatches()
        {
            for (int i = 0; i < 20; i++)
            {
                SendOrder(1);
                SendOrder(10);
            }
        }

        private void SendOrder(int quantity)
        {
            var message = string.Format("{0} widgets ordered.", quantity);
            var body = Encoding.UTF8.GetBytes(message);

            var properties = _channel.CreateBasicProperties();
            properties.SetPersistent(true);

            _channel.BasicPublish("", QueueName, properties, body);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }
    }
}