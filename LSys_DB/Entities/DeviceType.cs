using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class DeviceType
    {
        [Column("DeviceTypeId")]
        public int Id { get; set; }
        public string Type { get; set; }
        // Relacja jeden do wielu do Device
        public ICollection<Device> Devices { get; set; } = new List<Device>();

    }
}
