using AutoMapper;
using LSys.Services;
using LSys.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace LSys.Controllers
{
    public class MQTTController : Controller
    {
        private readonly IMQTTService _mqttService;
        private readonly IMapper _mapper;

        public MQTTController( IMQTTService MQTTService, IMapper mapper )
        {
            _mqttService = MQTTService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpGet("/MQTT/Add/{deviceId}")]
        public IActionResult Add([FromRoute] Guid deviceId)
        {
            return View();
        }


        [HttpPost("/MQTT/Add/{deviceId}")]
        public async Task<IActionResult> Add([FromRoute] Guid deviceId, [FromForm] AddMQTTVM mqttVM)
        {
            await _mqttService.AddMQTTServer(mqttVM, deviceId);
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
