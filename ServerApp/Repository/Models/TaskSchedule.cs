namespace family_tasks.Repository.Models;

public class TaskSchedule
{
    public int Id { get; set; }
    public required FamilyTask Task { get; set; }
    public required bool Active { get; set; } = true;

    public FamilyMember? Asignee { get; set; }

    // Options:
    // - High (0)
    // - Medium (5000) (default)
    // - Low (10000)
    public const int DefaultPriority = 5000;
    public int Priority { get; set; } = DefaultPriority;

    public DateOnly StartDate { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }

    public Frequency Frequency { get; set; }

    // Optional, only if Frequency == Custom and times are selected
    public TimeOnly[]? TimesOfTheDay { get; set; }
    // Optional, only if Frequency == Custom and days are selected
    public DayOfWeek[]? DaysOfTheWeek { get; set; }

    public EndCondition EndCondition { get; set; }

    // Optional, only if EndCondition == NumberOfOccurrences
    public int? NumberOfOccurrences { get; set; }
    // Optional, only if EndCondition == OnDate
    public DateOnly? EndDate { get; set; }

    // Generated programatically on create/update
    public List<TaskOccurrence>? TaskOccurrences { get; set; }
}

public enum Frequency
{
    Once = 0,
    Hourly = 1,
    Daily = 2,
    Weekly = 3,
    Monthly = 4,
    Yearly = 5,
    Custom = 6,
}

public enum EndCondition
{
    Never = 0,
    NumberOfOccurrences = 1,
    OnDate = 2,
}
