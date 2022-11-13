using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSys_DB.Entities.Schedulers;
using LSys_DB.Entities.Sensors;

namespace LSys_DB.Entities
{
    public class Device
    {
        [Column("DeviceId")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        //public int SensorId { get; set; }
        public int WiFiCredentialsId { get; set; }
        public WiFiCredentials WiFiCredentials { get; set; }
        public int MQTTCredentialsId { get; set; }
        public MQTTCredentials MQTTCredentials { get; set; }
        public List<User> Users { get; set; }
        public List<Sensor> Sensors { get; set; }
        public List <Dimmer> Dimmers { get; set; }
    }
}
