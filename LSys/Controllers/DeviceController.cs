using LSys.Services;
using LSys.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace LSys.Controllers
{
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
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
