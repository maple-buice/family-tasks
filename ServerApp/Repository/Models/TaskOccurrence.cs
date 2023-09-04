namespace family_tasks.Repository.Models;

public class TaskOccurrence
{
    public long Id { get; set; }
    public required TaskSchedule TaskSchedule { get; set; }

    public DateOnly Date { get; set; }
    private TimeOnly? startTime;
    public TimeOnly? StartTime
    {
        get { return startTime ?? TaskSchedule.StartTime; }
        set { startTime = value; }
    }
    private TimeOnly? endTime;
    public TimeOnly? EndTime
    {
        get { return endTime ?? TaskSchedule.EndTime; }
        set { endTime = value; }
    }

    public FamilyMember? asignee;
    public FamilyMember? Asignee
    {
        get { return asignee ?? TaskSchedule.Asignee; }
        set { asignee = value; }
    }

    // Default to TaskSchedule value, 5000 (medium)
    // if dragged to top 0 (high)
    // if dragged to bottom then 10000 (low)
    // if dragged between two that are 5000, assign above to 0, below to 10000
    // if dragged between two that are not 5000, set to half way between the above and below
    private int? priority;
    public int? Priority
    {
        get { return priority ?? TaskSchedule.Priority; }
        set { priority = value; }
    }
}