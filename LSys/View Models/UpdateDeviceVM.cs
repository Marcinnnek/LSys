namespace LSys.View_Models
{
    public class UpdateDeviceVM
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Group { get; set; }
    }
}
