
namespace LSys_DB.Entities
{
    public class WiFiCredentials
    {
        public int Id { get; set; }
        public string SSID { get; set; }
        public string Password { get; set; }
        public string DeviceIP { get; set; }
        public string GateWay { get; set; }
        public string ResetPassword { get; set; }
        public List<Device> Devices { get; set; } // WiFi credentials mogą byc przypisane do wielu urządzeń
    }
}
