using LSys_Domain.Entities.Schedulers;
using LSys_Domain.Entities.Sensors;
using LSys_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DataAccess.DTOs
{
    public class DeviceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Group { get; set; } // Podział urządzeń na grupy? Może się przydać? 
        public Guid? WiFiCredentialsId { get; set; }
        public WiFiCredentialsDTO WiFiCredentials { get; set; }
        public Guid? MQTTCredentialsId { get; set; }
        public MQTTCredentialsDTO MQTTCredentials { get; set; }
        //public List<UserDTO> Users { get; set; }
        public List<SensorDTO> Sensors { get; set; }
        public List<RelayDTO> Relays { get; set; }
    }
}
