namespace family_tasks.Repository.Models;

public class TaskSchedule
{
    public int Id { get; set; }
    public required FamilyTask Task { get; set; }

    public Frequency Frequency { get; set; }
    public DayOfWeek[]? DaysOfTheWeek { get; set; }
    public DateTime? EndsAt { get; set; }
}

public enum Frequency
{
    Hourly = 0,
    Daily = 1,
    Weekly = 2,
    Monthly = 3,
    Yearly = 4
}
