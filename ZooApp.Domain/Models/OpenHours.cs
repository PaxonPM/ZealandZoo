namespace ZooApp.Domain.Models
{
    public class OpenHours
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
    }
}
