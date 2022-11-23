using LSys.View_Models;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.UOW;
using LSys_Domain.Entities;
using System.Text.RegularExpressions;

namespace LSys.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddNewDevice(AddDeviceVM deviceVM)
        {
            if (deviceVM != null)
            {
                DeviceDTO newDevice = new DeviceDTO()
                {
                    Name = deviceVM.Name,
                    Description = deviceVM.Description,
                    Location = deviceVM.Location,
                    Group = deviceVM.Group,
                };
                newDevice.Id = (Guid)_unitOfWork.Devices.Add(newDevice);

            }
            var result = await _unitOfWork.Complete();
            return result > 0 ? true : false;
        }

        public async Task<bool> AddWiFiCredentials(Guid deviceId, AddWiFiVM wifiVM)
        {
            if (deviceId != null || wifiVM != null)
            {

                var device = _unitOfWork.Devices.GetDeviceByIdAsNoTracking(deviceId);
                List  <DeviceDTO>  devices= new List<DeviceDTO>() ;
                DeviceDTO newDevice = new DeviceDTO()
                {
                    Name = "deviceVM.Name",
                    Description = "deviceVM.Description",
                    Location = "deviceVM.Location",
                    Group = "dev",
                };
                //devices.Add(newDevice);
                WiFiCredentialsDTO newWiFiC = new WiFiCredentialsDTO()
                {
                    SSID = wifiVM.SSID,
                    Password = wifiVM.Password,
                    DeviceIP = wifiVM.DeviceIP,
                    GateWay = wifiVM.GateWay,
                    ResetPassword = wifiVM.ResetPassword,
                    //Devices = devices
                };


                //newDevice.WiFiCredentials = newWiFiC;
                //newDevice.Id= (Guid)_unitOfWork.Devices.Add(newDevice);
                newWiFiC.Id = (int)_unitOfWork.WiFiCredentials.Add(newWiFiC);

                device.WiFiCredentialsId = newWiFiC.Id;
            }
            var result = await _unitOfWork.Complete();
            return result > 0 ? true : false;
        }
    }
}
