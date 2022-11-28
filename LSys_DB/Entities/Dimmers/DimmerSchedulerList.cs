using LSys_Domain.Entities.Schedulers;

namespace LSys_Domain.Entities.Dimmers
{
    public class DimmerSchedulerList
    {
        public int DimmerId { get; set; }
        public Dimmer Dimmer { get; set; }
        public int SchedulerId { get; set; }
        public Scheduler Scheduler { get; set; }
    }
}
