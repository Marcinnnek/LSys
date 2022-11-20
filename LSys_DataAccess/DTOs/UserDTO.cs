using LSys_Domain.Entities;
using System.Runtime.Serialization;

namespace LSys_DataAccess.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }

        public List<RoleDTO> Roles { get; set; }
        // Relacja jeden do wielu do Device
        public List<DeviceDTO> Devices { get; set; }// = new List<Device>();
    }


}
