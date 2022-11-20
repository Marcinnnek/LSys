using LSys_Domain.Entities;

namespace LSys_DataAccess.DTOs
{
    public class UserRoleListDTO
    {
        public Guid RoleId { get; set; }
        public RoleDTO Role { get; set; }

        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
