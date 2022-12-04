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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var deviceVM = new AddDeviceVM();
            return View(deviceVM);
        }

        [HttpPost]
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


        //[HttpPost]
        //public async Task<IActionResult> AddWiFiCredentials([FromRoute] Guid Id, [FromBody] AddWiFiVM wifiVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _deviceService.AddWiFiCredentials(Id, wifiVM);
        //        if (result == true)
        //        {
        //            return StatusCode(201);
        //        }
        //        else
        //        {
        //            return NoContent();
        //        }
        //    }
        //    return NoContent();
        //}

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {

            var result = await _deviceService.GetDevice(id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _deviceService.DeleteDevice(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            var deviceVM = _mapper.Map<UpdateDeviceVM>(await _deviceService.GetDevice(id));

            return View(deviceVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateDeviceVM deviceVM)
        {
            await _deviceService.UpdateDevice(deviceVM);
            return RedirectToAction("Index");
        }
    }
}
