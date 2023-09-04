using family_tasks.Repository.Models;
using family_tasks.Repositories;

namespace family_tasks.Services;

public class TaskOccurrenceService
{
    private readonly TaskContext _context;

    public TaskOccurrenceService(TaskContext context)
    {
        _context = context;
    }

    public IEnumerable<TaskOccurrence> GetFamilyTaskOccurrences()
    {
        return _context.TaskOccurrences.ToList();
    }

    public TaskOccurrence? GetById(long id)
    {
        return _context.TaskOccurrences.SingleOrDefault(e => e.Id == id);
    }

    public enum Scope
    {
        Single = 0,
        All = 1,
        AllFollowing = 2
    }

    public void Update(TaskOccurrence taskEvent, Scope scope)
    {
        if (scope == Scope.Single)
            _context.TaskOccurrences.Update(taskEvent);
        else BulkUpdate(taskEvent, scope);
    }

    public void BulkUpdate(TaskOccurrence taskEvent, Scope scope)
    {
        var baseEvent = GetById(taskEvent.Id) ?? throw new KeyNotFoundException();

        if (baseEvent.Priority != taskEvent.Priority)
        {
            taskEvent.TaskSchedule.Priority = taskEvent.Priority ?? TaskSchedule.DefaultPriority;
        }

        if (baseEvent.StartTime != taskEvent.StartTime)
        {
            taskEvent.TaskSchedule.StartTime = taskEvent.StartTime;
        }

        if (baseEvent.EndTime != taskEvent.EndTime)
        {
            taskEvent.TaskSchedule.EndTime = taskEvent.EndTime;
        }

        _context.TaskSchedules.Update(taskEvent.TaskSchedule);

        taskEvent.TaskSchedule.TaskOccurrences?
            .Where(x => scope == Scope.All
                || (scope == Scope.AllFollowing
                    && x.Date >= taskEvent.Date
                    && x.StartTime >= taskEvent.StartTime))
            .ToList()
            .ForEach(e =>
            {
                if (baseEvent.Asignee != taskEvent.Asignee)
                {
                    e.Asignee = null;
                }
                if (baseEvent.Priority != taskEvent.Priority)
                {
                    e.Priority = null;
                }
                if (baseEvent.StartTime != taskEvent.StartTime)
                {
                    e.StartTime = null;
                }
                if (baseEvent.EndTime != taskEvent.EndTime)
                {
                    e.EndTime = null;
                }

                _context.TaskOccurrences.Update(e);
            });
    }

    public void Delete(int id, Scope scope)
    {
        var taskOccurrence = GetById(id);
        if (taskOccurrence == null) throw new KeyNotFoundException();

        if (scope == Scope.Single)
            _context.TaskOccurrences.Remove(taskOccurrence);
        else BulkDelete(taskOccurrence, scope);
    }

    public void BulkDelete(TaskOccurrence taskOccurrence, Scope scope)
    {
        if (scope == Scope.All)
        {
            _context.TaskSchedules.Remove(taskOccurrence.TaskSchedule);
        }
        else
        {
            var occurrencesToRemove = taskOccurrence.TaskSchedule
                .TaskOccurrences?
                .Where(x => scope == Scope.All
                    || (scope == Scope.AllFollowing
                        && x.Date >= taskOccurrence.Date
                        && x.StartTime >= taskOccurrence.StartTime));
            if (occurrencesToRemove != null)
                _context.TaskOccurrences.RemoveRange(occurrencesToRemove.ToArray());

            taskOccurrence.TaskSchedule.Active = false;
            _context.TaskSchedules.Update(taskOccurrence.TaskSchedule);
        }
    }
}