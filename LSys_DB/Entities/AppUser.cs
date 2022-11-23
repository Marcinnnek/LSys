using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSys_Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string ?Description { get; set; }

        // Relacja jeden do wielu do Device
        public List<Device> Devices { get; set; }// = new List<Device>();
    }
}
