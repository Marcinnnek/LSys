﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LSys_Domain.Entities
{
    public class MQTTCredentials : EntityBase<Guid>
    {
        public string ServerIp { get; set; }
        public string Port { get; set; }
        public string MQTTId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Device Device { get; set; }

    }
}
