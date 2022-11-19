namespace LSys_Domain.Entities
{
    public class UserDeviceList
    {
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
