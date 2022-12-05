using AutoMapper;
using LSys.View_Models;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.UOW;
using LSys_Domain.Entities;

namespace LSys.Services
{
    public class MQTTService : IMQTTService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MQTTService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DbResult<MQTTCredentialsDTO>> AddMQTTServer(AddMQTTVM mqttVM, Guid deviceId)
        {
            var mqttDTO = _mapper.Map<MQTTCredentialsDTO>(mqttVM);
            Console.WriteLine("test");
            if (mqttVM != null)
            {
                mqttDTO.Id = (Guid)_unitOfWork.MQTTCredentials.Add(mqttDTO);
                var device = _unitOfWork.Devices.GetDeviceByIdAsNoTracking(deviceId);
                device.MQTTCredentialsId = mqttDTO.Id;
                _unitOfWork.Devices.Update(device);
            }
            var result = new DbResult<MQTTCredentialsDTO>()
            {
                Result = await _unitOfWork.Complete(),
                DTOEntity = mqttDTO
            };
            return result;
        }
    }
}
