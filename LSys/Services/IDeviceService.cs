using LSys.View_Models;
using LSys_DataAccess.DTOs;

namespace LSys.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDTO>> GetDevices();
        Task<bool> AddNewDevice(AddDeviceVM deviceVM);
        Task<bool> AddWiFiCredentials(Guid deviceId, AddWiFiVM wifiVM);
    }
}
