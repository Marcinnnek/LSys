using System.ComponentModel.DataAnnotations.Schema;

namespace LSys_DB.Entities
{
    public class MQTTCredentials
    {
        public int Id { get; set; }
        public string ServerIp { get; set; }
        public string Port { get; set; }
        public string MQTTId{ get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Device Device { get; set; }


    }
}
