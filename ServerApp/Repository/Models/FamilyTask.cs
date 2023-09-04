namespace family_tasks.Repository.Models;

public class FamilyTask
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public string? Summary { get; set; }
    public Category? Category { get; set; }

    public required TaskSchedule TaskSchedule { get; set; }
}
