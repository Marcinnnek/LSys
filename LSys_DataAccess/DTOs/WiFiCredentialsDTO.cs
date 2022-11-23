using LSys_Domain.Entities;

namespace LSys_DataAccess.DTOs
{
    public class WiFiCredentialsDTO
    {
        public int Guid { get; set; }
        public string SSID { get; set; }
        public string Password { get; set; }
        public string DeviceIP { get; set; }
        public string GateWay { get; set; }
        public string? ResetPassword { get; set; }
        public List<DeviceDTO> Devices { get; set; }
    }
}