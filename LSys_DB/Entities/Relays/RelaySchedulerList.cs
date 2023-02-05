using LSys_Domain.Entities.Schedulers;

namespace LSys_Domain.Entities.Relays
{
    public class RelaySchedulerList
    {
        public int RelayId { get; set; }
        public Relay Relay { get; set; }
        public int SchedulerId { get; set; }
        public Scheduler Scheduler { get; set; }
    }
}
