using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class MQTTCredentials
    {
        [Column("MQTTCredentialsId")]
        public int Id { get; set; }
        public string ServerIp { get; set; }
        public string Port { get; set; }
        public string MQTTId{ get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Device Device { get; set; }


    }
}
