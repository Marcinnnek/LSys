using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
// ESP_2 usertest
namespace LSys.Services
{
    public class MQTTHandler : BackgroundService, IMQTTHandler
    {
        private IMqttClient _client;
        public event EventHandler<MQTTEventArgs> incomingMessage;


        public MQTTHandler(string clientId, string serverIp, string port, string clientLogin, string clientPassword)
        {
            var mqttFactory = new MqttFactory();
            _client = mqttFactory.CreateMqttClient();
            var clientOptions = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(serverIp)
                .WithCleanSession()
                .WithWillRetain()
                .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .WithCredentials(clientLogin, clientPassword)
                .Build();

            _client.ConnectAsync(clientOptions).Wait();

            _client.SubscribeAsync("Device.ESP_1.EnviromentParameters");
            _client.SubscribeAsync("Device.ESP_1.Lux");

            _client.ApplicationMessageReceivedAsync += RecieveMessage;
        }



        public async Task PublishMessageAsync(string payload)
        {
            //string messagePayload = $"Test Message {DateTime.Now}";
            string messagePayload = $"RL010000";
            var message = new MqttApplicationMessageBuilder()
                .WithTopic("DimmerSettings.ESP_1")
                .WithPayload(messagePayload)
                .WithRetainFlag(true)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
                .Build();

            if (_client.IsConnected)
            {
                await _client.PublishAsync(message);
            }
            else
            {
                await _client.ReconnectAsync();
                if (_client.IsConnected)
                {
                    await _client.PublishAsync(message);
                }
            }
        }

        public static async Task<string> RecieveMessage(MqttApplicationMessageReceivedEventArgs payload)
        {
            var message = Encoding.UTF8.GetString(payload.ApplicationMessage.Payload);
            Debug.WriteLine(message);

            return message;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //_client.IsConnected
            if (stoppingToken.IsCancellationRequested)
            {

                return Task.CompletedTask;
            }
            return Task.CompletedTask;
            Debug.WriteLine("");
        }

        public class MQTTEventArgs : EventArgs
        {
            string message;
        }

        protected virtual void ProcessMessage()
        {

        }
    }
}
