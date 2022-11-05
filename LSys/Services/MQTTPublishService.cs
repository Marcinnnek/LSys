using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace LSys.Services
{
    public class MQTTPublishService : BackgroundService
    {
        private IServiceProvider _sp;
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        private string exchangeName = "mqtt.topic";

        string queueName = "DimmerSettings.ESP_1";
        string deviceRoutingKey = "DimmerSettings" + ".#"; //Wybieranie widomości na podstawie nazwy urządzenia - loginu

        public MQTTPublishService(IServiceProvider sp)
        {
            
            _sp = sp;
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic, durable: true);

            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            _channel.QueueBind(
                queue: queueName,
                exchange: exchangeName,
                routingKey: deviceRoutingKey);

            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);


        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Thread.Sleep(5000);
                if (stoppingToken.IsCancellationRequested)
                {
                    _channel.Dispose();
                    _connection.Dispose();

                    return Task.CompletedTask;
                }


                string message = "Message published on C# client!";
                var body = Encoding.UTF8.GetBytes(message);

                _channel.BasicPublish(exchange: exchangeName,
                                     routingKey: deviceRoutingKey,
                                     basicProperties: null,
                                     body: body);
            }
            return Task.CompletedTask;

        }
    }
}
