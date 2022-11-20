using AutoMapper;
using LSys_DataAccess.DTOs;
using LSys_Domain.Entities;

namespace LSys_DataAccess.MappingDTOs
{
    public class MappingDTOsProfile :Profile
    {
        public MappingDTOsProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UserRoleList, UserRoleListDTO>().ReverseMap();
        }
    }
}
