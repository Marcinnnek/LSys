namespace LSys_Domain.Entities
{
    public class UserDeviceList
    {
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
