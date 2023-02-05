using LSys_DataAccess.DTOs;

namespace LSys.View_Models
{
    public class GetDeviceVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Group { get; set; }
        public List<RelayDTO> Relays { get; set; }

    }
}
