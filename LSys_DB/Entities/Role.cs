using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSys_Domain.Entities
{
    public class Role : EntityBase<Guid>
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}