using AutoMapper;
using LSys.Services;
using LSys.View_Models;
using LSys_DataAccess.DTOs;
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

        //[HttpGet("Add")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var deviceVM = new AddDeviceVM();
            return View(deviceVM);
        }

        //[HttpPost("Device/Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddDeviceVM deviceVM)
        {
            if (ModelState.IsValid)
            {
                var newDeviceDTO = _mapper.Map<DeviceDTO>(deviceVM);
                var result = await _deviceService.AddNewDevice(newDeviceDTO);
                if (result.Result > 0)
                {
                    return Redirect("~/Views/Home/Index.cshtml");
                }
                return View(deviceVM);
            }
            return View(deviceVM);
        }


        //[HttpPost("AddWiFiCredentials/{Id}")]
        [HttpPost]
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

        //[HttpGet("Device/Details")]
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {

            var result = await _deviceService.GetCurrentDevice(id);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Delete ([FromRoute]Guid id)
        {
            var result = await _deviceService.GetCurrentDevice(id);
            return PartialView("_DeletePartialView", result);
        }

        //public async Task<IActionResult> Delete(GetDeviceVM device)
        //{
        //    return PartialView("DeletePartialView", result);
        //}
    }
}
