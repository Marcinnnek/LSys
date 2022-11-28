using AutoMapper;
using LSys.Services;
using LSys.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace LSys.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allDevices = await _deviceService.GetDevices();
            var result = _mapper.Map<IEnumerable<GetDeviceVM>>(allDevices);
            return View(result);
        }

        [HttpPost("AddDevice")]
        public async Task<IActionResult> AddNewDevice([FromBody] AddDeviceVM deviceVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _deviceService.AddNewDevice(deviceVM);
                if (result == true)
                {
                    return StatusCode(201);
                }
                else
                {
                    return NoContent();
                }
            }
            return NoContent();
        }

        [HttpPost("AddWiFiCredentials/{Id}")]
        public async Task<IActionResult> AddWiFiCredentials([FromRoute] Guid Id, [FromBody] AddWiFiVM wifiVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _deviceService.AddWiFiCredentials(Id, wifiVM);
                if (result == true)
                {
                    return StatusCode(201);
                }
                else
                {
                    return NoContent();
                }
            }
            return NoContent();
        }
    }
}
