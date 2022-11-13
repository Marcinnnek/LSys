using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities.Sensors
{
    public class Readings
    {
        public int Id { get; set; }
        public DateTime MeasureDate { get; set; }
        public float Value { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
