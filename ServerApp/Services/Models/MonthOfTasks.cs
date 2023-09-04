namespace family_tasks.Services.Models;

public class MonthOfTasks
{
    public int Month { get; set; }
    public int Year { get; set; }
    public required List<DayOfTasks> Days { get; set; }
}