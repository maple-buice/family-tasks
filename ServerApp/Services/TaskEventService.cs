using family_tasks.Repository.Models;
using family_tasks.Repositories;

namespace family_tasks.Services;

public class TaskEventService
{
    private readonly TaskContext _context;

    public TaskEventService(TaskContext context)
    {
        _context = context;
    }

    public IEnumerable<TaskEvent> GetFamilyTaskOccurrences()
    {
        return _context.TasksOccurrences.ToList();
    }

    public TaskEvent? GetById(int id)
    {
        return _context.TasksOccurrences.SingleOrDefault(e => e.Id == id);
    }
}