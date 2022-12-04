using LSys_Domain.Entities;

namespace LSys.View_Models
{
    public class GetMQTTVM
    {
        public string ServerIp { get; set; }
        public string Port { get; set; }
        public string MQTTId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
