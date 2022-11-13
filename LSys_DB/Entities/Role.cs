using System.ComponentModel.DataAnnotations.Schema;

namespace LSys_DB.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public Guid UserId { get; set; }
        public List<User> Users { get; set; }
    }
}
