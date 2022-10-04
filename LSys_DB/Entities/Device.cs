using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class Device
    {
        [Column("DeviceId")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SensorId { get; set; }
        public int WiFiCredentialsId { get; set; }
        public int MQTTCredentialsId { get; set; }
        // Relacja jeden do wielu do User
        public User User { get; set; }
        public int UserId { get; set; }
        // Relacja jeden do wielu do DeviceType
        public int DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }

    }
}
