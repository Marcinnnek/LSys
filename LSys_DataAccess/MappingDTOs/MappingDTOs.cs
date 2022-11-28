using AutoMapper;
using LSys_DataAccess.DTOs;
using LSys_Domain.Entities;
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
        }
    }
}
