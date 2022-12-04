using AutoMapper;
using LSys.View_Models;
using LSys_DataAccess.DTOs;

namespace LSys.Mapping_Profiles
{
    public class MappingProfileVM :Profile
    {
        public MappingProfileVM()
        {
            CreateMap<GetDeviceVM, DeviceDTO>().ReverseMap();
            CreateMap<AddDeviceVM, DeviceDTO>().ReverseMap();
            CreateMap<UpdateDeviceVM, DeviceDTO>().ReverseMap();
            CreateMap<UpdateDeviceVM, GetDeviceVM>().ReverseMap();

        }
    }
}
