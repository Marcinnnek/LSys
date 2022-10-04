using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class WiFiCredentials
    {
        [Column("WiFiCredentialsId")]
        public int Id { get; set; }
        public string SSID { get; set; }
        public string Password { get; set; }
        public string DeviceIP { get; set; }
        public string GateWay { get; set; }
        public string ResetPassword { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
