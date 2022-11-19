using System.ComponentModel.DataAnnotations.Schema;

namespace LSys_Domain.Entities
{
    public class User :EntityBase<Guid>
    {
        //public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ?Description { get; set; }
        public string Email { get; set; }
        // Relacja wiele do wielu do User-Role
        public List<Role> Roles { get; set; }
        // Relacja jeden do wielu do Device
        public List<Device> Devices { get; set; }// = new List<Device>();
    }
}
