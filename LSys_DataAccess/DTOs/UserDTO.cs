using LSys_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace LSys_DataAccess.DTOs
{
    public class UserDTO : IdentityUser
    {
        public string? Description { get; set; }

        // Relacja jeden do wielu do Device
        public List<DeviceDTO> Devices { get; set; }// = new List<Device>();
    }


}
