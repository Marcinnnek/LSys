using LSys_DataAccess.DTOs;
using LSys_DataAccess.UOW;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
// ESP_2 usertest
namespace LSys.Services
{
    public class MQTTHandler : IMQTTHandler
    {
        private IMqttClient _client;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly MQTTSettings _mqttSettingsService;

        public IMqttClient ClientMQTT{ get { return _client; }  }
        public MQTTHandler(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            _mqttSettingsService = _serviceProvider.GetRequiredService<MQTTSettings>();
            _unitOfWork = (_serviceProvider.CreateScope()).ServiceProvider.GetRequiredService<IUnitOfWork>();
            var credenials = GetOwnCredentials();

            var mqttFactory = new MqttFactory();
            _client = mqttFactory.CreateMqttClient();
            var clientOptions = new MqttClientOptionsBuilder()
                .WithClientId(credenials.MQTTId)
                .WithTcpServer(credenials.ServerIp)
                .WithCleanSession()
                .WithWillRetain()
                .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .WithCredentials(credenials.Login, credenials.Password)
                .Build();

            _client.ConnectAsync(clientOptions).Wait();

            _client.SubscribeAsync("Device.ESP_1.EnviromentParameters");
            _client.SubscribeAsync("Device.ESP_1.Lux");

            _client.ApplicationMessageReceivedAsync += RecieveMessage;
            
        }


        private MQTTCredentialsDTO GetOwnCredentials()
        {
            var mqttCrednetials = _unitOfWork.MQTTCredentials.GetMQTTCredentiaslsByLogin(_mqttSettingsService.Login);
            _unitOfWork.Complete();
            return mqttCrednetials;
        }

        public static async Task<string> RecieveMessage(MqttApplicationMessageReceivedEventArgs payload)
        {
            var message = Encoding.UTF8.GetString(payload.ApplicationMessage.Payload);
            Debug.WriteLine(message);

            return message;
        }

        //protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    //_client.IsConnected
        //    if (stoppingToken.IsCancellationRequested)
        //    {

        //        return Task.CompletedTask;
        //    }
        //    return Task.CompletedTask;

        //}

        public IMqttClient GetClient(string clientId, string serverIp, string port, string clientLogin, string clientPassword)
        {
            IMqttClient _client;
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

            return _client;
        }

        public static async Task PublishMessageAsync(string payload, IMqttClient client, string topicPart)
        {
            string topic = $"DimmerSettings.{topicPart}";

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithRetainFlag(true)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
                .Build();

            if (client.IsConnected)
            {
                await client.PublishAsync(message);
            }
            else
            {
                await client.ReconnectAsync();
                if (client.IsConnected)
                {
                    await client.PublishAsync(message);
                }
            }
        }




    }
}
