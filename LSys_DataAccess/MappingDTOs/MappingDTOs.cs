using AutoMapper;
using LSys_DataAccess.DTOs;
using LSys_Domain.Entities;
using LSys_Domain.Entities.Schedulers;
using Microsoft.AspNetCore.Identity;

namespace LSys_DataAccess.MappingDTOs
{
    public class MappingDTOsProfile :Profile
    {
        public MappingDTOsProfile()
        {
            CreateMap<AppUser, UserDTO>().ReverseMap();
            CreateMap<IdentityRole, RoleDTO>().ReverseMap();
            CreateMap<Device, DeviceDTO>().ReverseMap();
            CreateMap<WiFiCredentials, WiFiCredentialsDTO>().ReverseMap();
            CreateMap<MQTTCredentials, MQTTCredentialsDTO>().ReverseMap();
            CreateMap<Relay, RelayDTO>().ReverseMap();
        }
    }
}
