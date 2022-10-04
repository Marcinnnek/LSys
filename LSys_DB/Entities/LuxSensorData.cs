using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class LuxSensorData
    {
        [Column("LuxDataId")]
        public int Id { get; set; }
        public int SensorId { get; set; }
        public float Measure { get; set; }
        public DateTime MeasureDate { get; set; }
    }
}
