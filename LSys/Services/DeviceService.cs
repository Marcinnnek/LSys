﻿using AutoMapper;
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

        public async Task<GetDeviceVM> GetDevice(Guid id)
        {
            var device = _mapper.Map<GetDeviceVM>(_unitOfWork.Devices.GetById(id));
            return device;
        }
        public async Task<DbResult<DeviceDTO>> AddNewDevice(AddDeviceVM deviceVM)
        {
            var deviceDTO = _mapper.Map<DeviceDTO>(deviceVM);
            if (deviceVM != null)
            {

                deviceDTO.Id = (Guid)_unitOfWork.Devices.Add(deviceDTO);
            }
            var result = new DbResult<DeviceDTO>()
            {
                Result = await _unitOfWork.Complete(),
                DTOEntity = deviceDTO
            };
            return result;
        }

        public async Task DeleteDevice(Guid id)
        {
            _unitOfWork.Devices.Remove(id);
            await _unitOfWork.Complete();
        }

        public async Task UpdateDevice(UpdateDeviceVM deviceVM)
        {
            var deviceDTO = _mapper.Map<DeviceDTO>(deviceVM);
            _unitOfWork.Devices.Update(deviceDTO);
            await _unitOfWork.Complete();
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
