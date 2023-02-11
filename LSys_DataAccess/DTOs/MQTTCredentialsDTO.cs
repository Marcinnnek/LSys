using LSys_Domain.Entities;

namespace LSys_DataAccess.DTOs
{
    public class MQTTCredentialsDTO
    {
        public Guid Id { get; set; }
        public string ServerIp { get; set; }
        public string Port { get; set; }
        public string MQTTId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DeviceDTO Device { get; set; }
    }
}