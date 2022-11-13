using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSys_DB.Entities.Sensors
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        // Relacja - jedeno urzadzenie ma wiele sensorów
        public Device Device { get; set; }
        public Guid DeviceId { get; set; }
        // Relacja - jeden sensor ma wiele odczytów
        public List<Readings> Readings { get; set; }
        // Relacja -  jeden sensor ma jedne ustawienia (opcjonalnie można - jeden sensor ma wiele ustawień)
        public int SensorSettingsId { get; set; }
        public SensorSettings SensorSettings { get; set; }

    }
}
