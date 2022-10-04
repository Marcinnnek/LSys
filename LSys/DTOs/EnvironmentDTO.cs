namespace LSys.DTOs
{
    public class EnvironmentDTO
    {
        public string DeviceLogin { get; set; }
        public string DeviceID { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }

        public override string? ToString()
        {
            return String.Format("Obj. details: {0}, {1}, {2}, {3}", DeviceLogin, DeviceID, Temperature, Humidity);
        }
    }
}