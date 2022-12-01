using AutoMapper;
using LSys.Models;
using LSys.Services;
using LSys.View_Models;
using LSys_DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;

        public HomeController(
            ILogger<HomeController> logger, 
            IDeviceService deviceService, 
            IMapper mapper)
        {
            _logger = logger;
            _deviceService = deviceService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var allDevices = await _deviceService.GetDevices();
            var devices = _mapper.Map<IEnumerable<GetDeviceVM>>(allDevices);
            //return View(result);
            return View("~/Views/Device/Index.cshtml", devices);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}