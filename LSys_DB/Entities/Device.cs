using System.ComponentModel.DataAnnotations.Schema;
using LSys_Domain.Entities.Schedulers;
using LSys_Domain.Entities.Sensors;

namespace LSys_Domain.Entities
{
    public class Device : EntityBase<Guid>
    {
        //public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Group { get; set; } // Podział urządzeń na grupy? Może się przydać? 
        public Guid? WiFiCredentialsId { get; set; }
        public WiFiCredentials? WiFiCredentials { get; set; }
        public Guid? MQTTCredentialsId { get; set; }
        public MQTTCredentials? MQTTCredentials { get; set; }
        public List<AppUser>? Users { get; set; }
        public List<Sensor>? Sensors { get; set; }
        public List<Dimmer>? Dimmers { get; set; }
    }
}
