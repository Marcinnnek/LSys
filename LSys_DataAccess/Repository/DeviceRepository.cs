using AutoMapper;
using LSys_DataAccess.DTOs;
using LSys_DataAccess.Repository_Interfaces;
using LSys_Domain;
using LSys_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository
{
    public class DeviceRepository : Repository<Device, DeviceDTO, Guid>, IDeviceRepository
    {
        public DeviceRepository(LSysDbContext _DbContext, IMapper mapper) : base(_DbContext, mapper)
        {
        }


        public IEnumerable<DeviceDTO> GetAllDevicesWithRelays()
        {
            var dbEntities = _dbContext.Devices.Include(d => d.Relays);
            var result = _mapper.Map<IEnumerable<Device>, IEnumerable<DeviceDTO>>(dbEntities);
            return result;
        }

        public DeviceDTO GetByIdAsNoTracking(Guid Id)
        {
            DeviceDTO deviceDTO = _mapper.Map<DeviceDTO>(_dbContext.Devices.AsNoTracking().FirstOrDefault(d => d.Id == Id));
            return deviceDTO;
        }

        public DeviceDTO GetDeviceWithIncludeAsNO(Guid Id)
        {
            DeviceDTO deviceDTO = _mapper.Map<DeviceDTO>(_dbContext.Devices.Include(d=>d.Relays).Include(d=>d.MQTTCredentials).AsNoTracking().FirstOrDefault(d => d.Id == Id));
            return deviceDTO;
        }
    }
}
