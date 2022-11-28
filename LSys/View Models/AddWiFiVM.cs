using LSys_Domain.Entities;

namespace LSys.View_Models
{
    public class AddWiFiVM
    {
        public string? SSID { get; set; }
        public string? Password { get; set; }
        public string? DeviceIP { get; set; }
        public string? GateWay { get; set; }
        public string? ResetPassword { get; set; }
    }
}
