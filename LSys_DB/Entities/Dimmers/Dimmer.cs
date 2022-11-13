using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities.Schedulers
{
    public class Dimmer
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public bool State { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device{ get; set; }
    }
}
