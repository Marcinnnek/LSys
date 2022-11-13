using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using LSys.DTOs;

namespace LSys.Services
{
    public class MQTTSubscribeService : BackgroundService
    {
        private IServiceProvider _sp;
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        string queueName = "Device.ESP_1.Lux";
        string deviceLogin = "ESP_1";

        


        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        public MQTTSubscribeService(IServiceProvider sp)
        {
            string deviceRoutingKey = "Device." + deviceLogin + ".#"; //Wybieranie widomości na podstawie nazwy urządzenia - loginu
            _sp = sp;
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            _channel.QueueBind(
                queue: queueName,
                exchange: "amq.topic",
                routingKey: deviceRoutingKey);

            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);


           

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                _channel.Dispose();
                _connection.Dispose();

                return Task.CompletedTask;
            }

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                DateTime date = UnixTimeStampToDateTime(ea.BasicProperties.Timestamp.UnixTime);
                //DateTime date2 = UnixTimeStampToDateTime(ea.BasicProperties.);

                //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + " " + message);
                //Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + " " + message);

                Console.WriteLine(date.ToString("HH:mm:ss:fff") + " " + message);
                //Debug.WriteLine(time.ToString() + " " + message);

                     

                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                using (StreamWriter writer = new StreamWriter(@"D:\message.txt", true))
                {
                    writer.WriteLineAsync(DateTime.Now.ToString("HH:mm:ss:fff") + " " + message);
                }

            };

            _channel.BasicConsume(queue: queueName,
                                 autoAck: false,
                                 consumer: consumer);
            return Task.CompletedTask;
        }
    }
}




