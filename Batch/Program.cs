using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Text.Json;
using Batch.Models;
using Interfaces;
using System.Threading;

namespace Batch
{
    class Program
    {
        public static IConnection Connection;
        public static string evnetName = "ResourcePublished";
        static void Main(string[] args)
        {
            
            Connection = (new ConnectionFactory()).CreateConnection();
            IModel channel = Connection.CreateModel();
            channel.ExchangeDeclare(evnetName, ExchangeType.Direct);
            string queueName = channel.QueueDeclare(evnetName, false, false, true, null).QueueName;
            channel.QueueBind(queueName, evnetName, "");
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                IMessage message = Deserlicere<Message>(ea.Body.ToArray());
                Console.WriteLine("Starting work on: " + message.guid);
                foreach (string format in message.Fromats)
                {
                    Console.WriteLine("starting Conversion to form: " + format);
                    Thread.Sleep((int)message.Length*100);
                }

                Console.WriteLine("Finshjob");
            };
            channel.BasicConsume(queueName, true, consumer);
            while (true)
            {
                Thread.Sleep(1);
            }
        }

        private static T Deserlicere<T>(byte[] json) where T : class
        {
            string message = Encoding.UTF8.GetString(json);
            return JsonSerializer.Deserialize<T>(message);
        }
    }
}
