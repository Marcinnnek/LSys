namespace LSys_DB.Entities
{
    public class UserDeviceList
    {
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
