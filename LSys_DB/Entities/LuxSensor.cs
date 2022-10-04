using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities
{
    public class LuxSensor
    {
        [Column("SensorId")]
        public int Id { get; set; }
        public float SetLux { get; set; }
        public bool SensorState { get; set; }
        public float MeasureTime { get; set; }
        public DateTime SettingsDate { get; set; }
        // Relacja jeden do wielu dla Sensor
        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
