using LSys_Domain.Enums;

namespace LSys_Domain.Entities.Schedulers
{
    public class Scheduler : IEntityBase<int>
    {
        public int Id { get; set; }
        public bool State { get; set; } // Harmonogram aktywny/nieaktywny
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAd { get; set; }
        public FrequencyType FrequencyType { get; set; } // Weekly, Monthly, itd.
        public int? FrequencyInterval { get; set; } // interval np weekly: 1-7, monthly: 1:30
        public DateTime? TimeOfDay { get; set; } // godzina wykonania
        public ActionType ActionType { get; set; } // Typ akcji: włącz, wyłącz, itd.
        public float SetValue { get; set; } // Wartość jaka ma zostać ustawiona na dimmerze
        public List<Relay> Relays { get; set; }
    }
}
