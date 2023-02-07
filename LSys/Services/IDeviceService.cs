using LSys.View_Models;
using LSys_DataAccess.DTOs;

namespace LSys.Services
{
    public interface IDeviceService
    {
        // dodac metode która wyszuka wszytkie ip w sieci oraz wyświetli tylko te które nie są przypisane do żadnego urządzenia
        Task<IEnumerable<DeviceDTO>> GetDevices();
        Task<GetDeviceVM> GetDevice(Guid id);
        Task<DeviceDTO> GetDeviceWithIncludeAsNO(Guid id);
        Task<DbResult<DeviceDTO>> AddNewDevice(AddDeviceVM deviceVM);
        Task DeleteDevice(Guid id);
        Task UpdateDevice(DeviceDTO deviceDTO);
        //Task<bool> AddWiFiCredentials(Guid deviceId, AddWiFiVM wifiVM);
    }
}
