using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class Role
    {
        [Column("RoleId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public Guid UserId { get; set; }
        public List<User> Users { get; set; }
    }
}
