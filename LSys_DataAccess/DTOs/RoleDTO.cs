using LSys_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSys_DataAccess.DTOs
{
    public class RoleDTO 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}