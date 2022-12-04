namespace LSys.View_Models
{
    public class GetWiFiVM
    {
        public Guid Id { get; set; }
        public string SSID { get; set; }
        public string Password { get; set; } = "***************";
        public string DeviceIP { get; set; }
        public string GateWay { get; set; }
        public string? ResetPassword { get; set; }
    }
}
