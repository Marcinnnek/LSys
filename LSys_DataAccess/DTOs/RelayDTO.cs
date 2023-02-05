using LSys_Domain.Entities.Schedulers;
using LSys_Domain.Entities;

namespace LSys_DataAccess.DTOs
{
    public class RelayDTO
    {
        public int Id { get; set; }
        public bool FirstChannelState { get; set; }
        public bool SecondChannelState { get; set; }
        public bool ThirdChannelState { get; set; }
        public bool FourthChannelState { get; set; }
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public List<Scheduler> Schedulers { get; set; }
    }
}