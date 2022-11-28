using LSys_DataAccess.DTOs;
using LSys_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.Repository_Interfaces
{
    public interface IDeviceRepository :IRepository<Device, DeviceDTO, Guid>
    {
        public DeviceDTO GetDeviceByIdAsNoTracking(Guid Id);
    }
}
