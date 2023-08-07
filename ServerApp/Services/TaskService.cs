using family_tasks.Repository.Models;
using family_tasks.Repositories;

namespace family_tasks.Services;

public class TaskService
{
    private readonly TaskContext _context;

    public TaskService(TaskContext context)
    {
        _context = context;
    }

    public FamilyTask Create(FamilyTask task) {
        _context.Tasks.Add(task);
        // TODO: Verify that this sets the Id by reference
        return task;
    }

    public IEnumerable<FamilyTask> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public FamilyTask? Get(int id) {
        return _context.Tasks.SingleOrDefault(e => e.Id == id);
    }

    public void Update(FamilyTask task) {
        _context.Tasks.Update(task);
    }

    public void Delete(int id) {
        _context.Remove(id);
    }
}