using family_tasks.Repository.Models;

namespace family_tasks.Services.Models;

public class DayOfTasks
{
    public DateOnly Day { get; set; }
    public required List<TaskOccurrence> Tasks { get; set; }
}