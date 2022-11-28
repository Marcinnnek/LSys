using LSys.View_Models;

namespace LSys.Services
{
    public interface IDeviceService
    {
        Task<bool> AddNewDevice(AddDeviceVM deviceVM);
        Task<bool> AddWiFiCredentials(Guid deviceId, AddWiFiVM wifiVM);
    }
}
