using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        // Relacja jeden do wielu do Role
        public int RoleId { get; set; }
        public Role Role { get; set; }
        // Relacja jeden do wielu do Device
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
