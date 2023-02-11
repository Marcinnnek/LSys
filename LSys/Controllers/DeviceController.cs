using AutoMapper;
using LSys.Services;
using LSys.View_Models;
using LSys_DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Server;
using System.Diagnostics;
using LSys_Domain.Entities;

namespace LSys.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            HostingEnvironment env = new HostingEnvironment();
            env.ContentRootPath = Directory.GetCurrentDirectory();
            env.EnvironmentName = "Development";


            _deviceService = deviceService;
            _mapper = mapper;
        }

        [HttpGet("[controller]/Index")]
        public async Task<IActionResult> Index()
        {
            var allDevices = await _deviceService.GetDevices();
            var result = _mapper.Map<IEnumerable<GetDeviceVM>>(allDevices);
            return View(result);
        }

        [HttpGet("[controller]/Add")]
        public async Task<IActionResult> Add()
        {
            var deviceVM = new AddDeviceVM();
            return View(deviceVM);
        }

        [HttpPost("[controller]/Add")]
        public async Task<IActionResult> Add([FromForm] AddDeviceVM deviceVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _deviceService.AddNewDevice(deviceVM);
                if (result.Result > 0)
                {
                    return RedirectToAction("Index");
                }
                return View(deviceVM);
            }
            return View(deviceVM);
        }

        [HttpGet("[controller]/Details/{Id}")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {

            var device = await _deviceService.GetDevice(id);

            var result = new GetDeviceMQTTWiFiVM()
            {
                deviceVM = device,
            };
            return View(result);
        }

        [HttpPost("[controller]/Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            await _deviceService.DeleteDevice(id);
            return RedirectToAction("Index");
        }

        [HttpGet("[controller]/Update/{Id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            var deviceVM = _mapper.Map<UpdateDeviceVM>(await _deviceService.GetDevice(id));

            return View(deviceVM);
        }
        [HttpPost("[controller]/Update/{Id}")]
        public async Task<IActionResult> Update([FromForm] UpdateDeviceVM deviceVM)
        {
            var deviceDTO = _mapper.Map<DeviceDTO>(deviceVM);
            await _deviceService.UpdateDevice(deviceDTO);
            return RedirectToAction("Index");
        }


        [HttpPost("[controller]/SetRelay")]
        public async Task<IActionResult> SetRelay([FromForm] SetRelays deviceRS)
        {
            //_deviceService.SetRelay(deviceRS);
            var client = _deviceService.GetMqttClient().Result;

            var device = await _deviceService.GetDeviceWithIncludeAsNO(deviceRS.Id);

            var deviceLogin = device.MQTTCredentials.Login;

            List<bool> relayState = new List<bool>() { deviceRS.FirstChannelState, deviceRS.SecondChannelState, deviceRS.ThirdChannelState, deviceRS.FourthChannelState };

            for (int i = 0; i < relayState.Count; i++)
            {
                Debug.WriteLine($"Relay state: {relayState[i]}");
                await PublishMessageAsync($"RL{(i+1):00}{(relayState[i]?1:0):0000}", client, deviceLogin);
            }

            device.Relays[0].FirstChannelState = deviceRS.FirstChannelState;
            device.Relays[0].SecondChannelState = deviceRS.SecondChannelState;
            device.Relays[0].ThirdChannelState = deviceRS.ThirdChannelState;
            device.Relays[0].FourthChannelState = deviceRS.FourthChannelState;
            await _deviceService.UpdateDevice(device);


            return RedirectToAction("Index");
        }

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

        public async Task PublishMessageAsync(string payload, IMqttClient client, string topicPart)
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
