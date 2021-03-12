using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace RabbitMQConections
{
    public class RabbitMQ
    {
        public ConnectionFactory Factory;
        public RabbitMQ(ConnectionFactory factory)
        {
            Factory = factory;
        }
        public void PublicMessage<T>(T message)
        {
            using (IConnection connection = Factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    string eventName = "ResourcePublished";

                    channel.ExchangeDeclare(eventName, ExchangeType.Direct);
                    channel.BasicPublish(eventName, "", null, Serlicere(message));
                }
            }
        }
        private byte[] Serlicere<T>(T Object)
        {
            var message = JsonSerializer.Serialize(Object);
            var body = Encoding.UTF8.GetBytes(message);
            return body;
        }
    }
}
