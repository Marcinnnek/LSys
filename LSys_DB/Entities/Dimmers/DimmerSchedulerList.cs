using LSys_DB.Entities.Schedulers;

namespace LSys_DB.Entities.Dimmers
{
    public class DimmerSchedulerList
    {
        public int DimmerId { get; set; }
        public Dimmer Dimmer { get; set; }
        public int SchedulerId { get; set; }
        public Scheduler Scheduler { get; set; }
    }
}
