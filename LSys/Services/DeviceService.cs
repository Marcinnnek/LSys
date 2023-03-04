﻿using AutoMapper;
using LSys.View_Models;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.UOW;
using LSys_Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MQTTnet.Client;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LSys.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MQTTHandler _mqttHandler;
        IServiceProvider _serviceProvider;

        public DeviceService(IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mqttHandler = _serviceProvider.GetRequiredService<MQTTHandler>();
        }

        public async Task<IMqttClient> GetMqttClient()
        {
            var client = _mqttHandler.ClientMQTT;
            return client;
        }

        public async Task<IEnumerable<DeviceDTO>> GetDevices()
        {
            var allDevices = _unitOfWork.Devices.GetAllDevicesWithRelays();
            await _unitOfWork.Complete();
            return allDevices;
        }
        public async Task<DeviceDTO> GetDeviceWithIncludeAsNO(Guid id)
        {
            var device = _mapper.Map<DeviceDTO>(_unitOfWork.Devices.GetDeviceWithIncludeAsNO(id));
            await _unitOfWork.Complete();
            return device;
        }

        public async Task<GetDeviceVM> GetDevice(Guid id)
        {
            var device = _mapper.Map<GetDeviceVM>(_unitOfWork.Devices.GetById(id));
            await _unitOfWork.Complete();
            return device;
        }
        public async Task<DbResult<DeviceDTO>> AddNewDevice(AddDeviceVM deviceVM)
        {
            var deviceDTO = _mapper.Map<DeviceDTO>(deviceVM);
            if (deviceVM != null)
            {
                var relay = new RelayDTO();
                deviceDTO.Relays.Add(relay);
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

        public async Task UpdateDevice(DeviceDTO deviceDTO)
        {
            //var deviceDTO = _mapper.Map<DeviceDTO>(deviceVM);
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
