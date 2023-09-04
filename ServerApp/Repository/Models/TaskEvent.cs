namespace family_tasks.Repository.Models;

public class TaskEvent
{
    public long Id { get; set; }
    public required FamilyTask FamilyTask { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }

    public FamilyMember? Asignee { get; set; }

    // Default to 5000
    // if dragged to top 0
    // if dragged to bottom then 10000
    // if dragged between two that are 5000, assign above to 0, below to 10000
    // if dragged between two that are not 5000, set to half way between the above and below
    public int Priority { get; set; }
}