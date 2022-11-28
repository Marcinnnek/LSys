using AutoMapper;
using LSys.View_Models;
using LSys_DataAccess.DTOs;

namespace LSys.Mapping_Profiles
{
    public class MappingProfileVM :Profile
    {
        public MappingProfileVM()
        {
            //CreateMap<DeviceDTO, GetDeviceVM>().ForMember(m => m.Id, c=>c.MapFrom(s=>s.Id)).ReverseMap();
            //CreateMap<DeviceDTO, GetDeviceVM>().ForMember(m => m.Name, c=>c.MapFrom(s=>s.Name)).ReverseMap();
            //CreateMap<DeviceDTO, GetDeviceVM>().ForMember(m => m.Description, c=>c.MapFrom(s=>s.Description)).ReverseMap();
            //CreateMap<DeviceDTO, GetDeviceVM>().ForMember(m => m.Location, c=>c.MapFrom(s=>s.Location)).ReverseMap();
            //CreateMap<DeviceDTO, GetDeviceVM>().ForMember(m => m.Group, c=>c.MapFrom(s=>s.Group)).ReverseMap();

            CreateMap<GetDeviceVM, DeviceDTO>().ReverseMap();

        }
    }
}
