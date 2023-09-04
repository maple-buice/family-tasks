using family_tasks.Repository.Models;
using family_tasks.Repositories;

namespace family_tasks.Services;

public class TaskService
{
    private readonly TaskContext _context;
    private readonly TaskScheduleService _taskScheduleService;

    public TaskService(
        TaskContext context,
        TaskScheduleService taskScheduleService)
    {
        _context = context;
        _taskScheduleService = taskScheduleService;
    }

    public FamilyTask Create(FamilyTask task)
    {
        _context.Tasks.Add(task);
        _taskScheduleService.Create(task.TaskSchedule);

        // TODO: Verify that this sets the Id by reference
        return task;
    }

    public IEnumerable<FamilyTask> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public FamilyTask? Get(int id)
    {
        return _context.Tasks.SingleOrDefault(e => e.Id == id);
    }

    public void Update(FamilyTask task)
    {
        _context.Tasks.Update(task);
    }

    public void Delete(int id)
    {
        var entity = _context.Tasks.SingleOrDefault(x => x.Id == id)
            ?? throw new KeyNotFoundException();

        _context.Tasks.Remove(entity);
    }
}