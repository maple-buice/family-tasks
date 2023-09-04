namespace family_tasks.Services.Models;

public class WeekOfTasks
{
    public DateOnly FirstDayOfWeek { get; set; }
    public DateOnly LastDayOfWeek { get; set; }
    public required List<DayOfTasks> Days { get; set; }
}