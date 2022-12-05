
namespace LSys_Domain.Entities
{
    public class WiFiCredentials : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string SSID { get; set; }
        public string Password { get; set; }
        public string DeviceIP { get; set; }
        public string GateWay { get; set; }
        public string? SecurityPassword { get; set; }
        public List<Device> Devices { get; set; } // WiFi credentials mogą byc przypisane do wielu urządzeń

    }
}
