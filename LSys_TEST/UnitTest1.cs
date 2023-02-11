using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using LSys;
using LSys_DataAccess;
using LSys_Domain;
using LSys.Services;
using System.Net;
using Moq;
using FluentAssertions;
using LSys_DataAccess.DTOs;
using LSys.Controllers;
using LSys_DataAccess.UOW;
using AutoMapper;
using LSys.View_Models;
using LSys_Domain.Entities;
//using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LSys_TEST
{
    public class BasicTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public BasicTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        private Mock<IDeviceService> _deviceService;

        private Mock<IServiceProvider> _iServiceProvider;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> mapper;


        [Fact]
        public async void AddNewDevice()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("https://localhost:7053/");
            response.Content.ReadAsStringAsync().Wait();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]

        public async void GetDevicesTEST()
        {
            IEnumerable<DeviceDTO> devices = new List<DeviceDTO>() { new DeviceDTO(), new DeviceDTO() };


            _deviceService = new Mock<IDeviceService>();

            _deviceService.Setup(x => x.GetDevices()).Returns(Task.FromResult(devices));

            var result = _deviceService.Object.GetDevices();

            result.Should().NotBeNull();
            result.Result.Should().HaveCount(2);
        }

        [Fact]
        public async void GetDeviceWithIdTEST()
        {
            var deviceGuid = new Guid("1EB47EC3-1F5B-48E7-1017-08DB07B5AFAE");

            GetDeviceVM device = new GetDeviceVM()
            {
                Id = new Guid("1EB47EC3-1F5B-48E7-1017-08DB07B5AFAE"),
                Name = "Device with Relays",
                Description = "Sample description",
                Location = "Sample Location",
                Group = "0",
                //MQTTCredentials = new MQTTCredentialsDTO(),
                //WiFiCredentials = new WiFiCredentialsDTO(),
                //WiFiCredentialsId = new Guid("5055625A-30E5-469B-3077-08DB094AAF57"),
                //MQTTCredentialsId = new Guid("DCA5F856-FC22-448F-BB5F-08DB094B505F")
            };

            _deviceService = new Mock<IDeviceService>();
            _deviceService.Setup(x => x.GetDevice(deviceGuid)).Returns(Task.FromResult(device));

            var result = _deviceService.Object.GetDevice(deviceGuid).Result;


            result.Should().NotBeNull();
            result.Id.Should().Be(deviceGuid);
        }

        [Fact]
        public async void AddNewDeviceTEST()
        {
            var deviceGuid = new Guid("1EB47EC3-1F5B-48E7-1017-08DB07B5AFAE");

            AddDeviceVM device = new AddDeviceVM()
            {
                Name = "Device with Relays",
                Description = "Sample description",
                Location = "Sample Location",
                Group = "0",
            };

            DeviceDTO deviceDTO = new DeviceDTO()
            {
                Id = new Guid("1EB47EC3-1F5B-48E7-1017-08DB07B5AFAE"),
                Name = "Device with Relays",
                Description = "Sample description",
                Location = "Sample Location",
                Group = "0",
            };

            var dbResult = new DbResult<DeviceDTO>()
            {
                DTOEntity = deviceDTO,
                Result = 1
            };

            _deviceService = new Mock<IDeviceService>();
            _deviceService.Setup(x => x.AddNewDevice(device)).Returns(Task.FromResult(dbResult));

            var result = _deviceService.Object.AddNewDevice(device).Result;


            result.Should().NotBeNull();
            result.Result.Should().Be(1);
            result.DTOEntity.Id.Should().Be(deviceDTO.Id);
            result.DTOEntity.Name.Should().Be(device.Name);
        }

        [Fact]
        public void DeleteDeviceTEST()
        {
            Guid Id = new Guid("1EB47EC3-1F5B-48E7-1017-08DB07B5AFAE");
            GetDeviceVM device = null;

            _deviceService = new Mock<IDeviceService>();
            _deviceService.Setup(x => x.DeleteDevice(Id));

            _deviceService.Object.DeleteDevice(Id);


            _deviceService.Setup(x => x.GetDevice(Id)).Returns(Task.FromResult(device));

            var result = _deviceService.Object.GetDevice(Id).Result;


            result.Should().BeNull();

        }
    }
}