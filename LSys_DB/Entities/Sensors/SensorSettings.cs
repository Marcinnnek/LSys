namespace LSys_DB.Entities.Sensors
{
    public class SensorSettings
    {
        public int Id { get; set; }
        public bool State { get; set; } = false;
        public float MeasurementPeriod { get; set; } = 60;
        public float Offset { get; set; } = 0;
        public DateTime SettingsUpdated { get; set; } = DateTime.Now;
        public Sensor Sensor { get; set; }
    }
}
