using System.Runtime.Serialization;

namespace LSys_DataAccess.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }
    }
}
