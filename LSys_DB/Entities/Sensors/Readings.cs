namespace LSys_Domain.Entities.Sensors
{
    public class Readings : IEntityBase<int>
    {
        public int Id { get; set; }
        public DateTime MeasureDate { get; set; }
        public float Value { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
