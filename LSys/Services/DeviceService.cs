using AutoMapper;
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
        private readonly IMapper _mapper;

        public DeviceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeviceDTO>> GetDevices()
        {
            var allDevices = _unitOfWork.Devices.GetAll();
            return allDevices;
        }

        public async Task<GetDeviceVM> GetCurrentDevice(Guid id)
        {
            var device = _mapper.Map<GetDeviceVM>(_unitOfWork.Devices.GetById(id));
            return device;
        }
        public async Task<DbResult<DeviceDTO>> AddNewDevice(DeviceDTO deviceVM)
        {
            if (deviceVM != null)
            {
                deviceVM.Id = (Guid)_unitOfWork.Devices.Add(deviceVM);
            }
            var result = new DbResult<DeviceDTO>()
            {
                Result = await _unitOfWork.Complete(),
                DTOEntity = deviceVM
            };
            return result;
        }

        public async Task<bool> AddWiFiCredentials(Guid deviceId, AddWiFiVM wifiVM)
        {
            if (deviceId != null || wifiVM != null)
            {
                WiFiCredentialsDTO newWiFiC = new WiFiCredentialsDTO()
                {
                    SSID = wifiVM.SSID,
                    Password = wifiVM.Password,
                    DeviceIP = wifiVM.DeviceIP,
                    GateWay = wifiVM.GateWay,
                    ResetPassword = wifiVM.ResetPassword,
                };

                newWiFiC.Id = (Guid)_unitOfWork.WiFiCredentials.Add(newWiFiC);

            }
            var result = await _unitOfWork.Complete();
            return result > 0 ? true : false;
        }
    }
}
