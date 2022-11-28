using LSys_Domain.Entities;

namespace LSys_DataAccess.DTOs
{
    public class UserRoleListDTO
    {
        public string RoleId { get; set; }
        public RoleDTO Role { get; set; }

        public string UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
