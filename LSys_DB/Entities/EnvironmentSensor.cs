using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{

    public class EnvironmentSensor
    {
        [Column("SensorId")]
        public int Id { get; set; }
        public float MeasureTime { get; set; }
        public bool SensorState { get; set; }
        public float TemperatureOffset { get; set; }
        public float HumidityOffset { get; set; }
        public DateTime MeasureDate { get; set; }

        //public string DeviceLogin { get; set; }
        //public string DeviceID { get; set; }
        //public float Temperature { get; set; }
        //public float Humidity { get; set; }

        //public override string? ToString()
        //{
        //    return String.Format("Obj. details: {0}, {1}, {2}, {3}", DeviceLogin, DeviceID, Temperature, Humidity);
        //}
    }

}
