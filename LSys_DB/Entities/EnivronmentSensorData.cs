using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class EnivronmentSensorData
    {
        [Column("EnvironmentSensorData")]
        public int Id { get; set; }
        public int SensorId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime MeasureDate { get; set; }
    }
}
