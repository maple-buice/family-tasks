using family_tasks.Repository.Models;
using family_tasks.Repositories;

namespace family_tasks.Services;

public class TaskScheduleService
{
    private readonly TaskContext _context;

    public TaskScheduleService(TaskContext context)
    {
        _context = context;
    }

    public TaskSchedule Create(TaskSchedule taskSchedule)
    {
        _context.TaskSchedules.Add(taskSchedule);
        PopulateOccurrences(taskSchedule);
        // TODO: Verify that this sets the Id by reference
        return taskSchedule;
    }

    // TODO: Write a job for managing TaskOccurrence population
    private int OccurrencesToCreate = 365;

    // TODO: Refine this logic, it's quite crude
    private void PopulateOccurrences(TaskSchedule taskSchedule)
    {
        var numberOfOccurrences = taskSchedule.NumberOfOccurrences ?? OccurrencesToCreate;
        var occurrencesToCreate = new List<TaskOccurrence>();

        if (taskSchedule.Frequency == Frequency.Once)
        {
            occurrencesToCreate.Add(new TaskOccurrence
            {
                TaskSchedule = taskSchedule,
                Date = taskSchedule.StartDate,
                StartTime = taskSchedule.StartTime,
                EndTime = taskSchedule.EndTime,
            });
        }
        else if (taskSchedule.Frequency == Frequency.Daily)
        {
            occurrencesToCreate.AddRange(
                Enumerable.Range(0, numberOfOccurrences)
                    .Select(x => new TaskOccurrence
                    {
                        TaskSchedule = taskSchedule,
                        Date = taskSchedule.StartDate.AddDays(x)
                    }));
        }
        else if (taskSchedule.Frequency == Frequency.Daily)
        {
            occurrencesToCreate.AddRange(
                Enumerable.Range(0, numberOfOccurrences)
                    .Select(x => new TaskOccurrence
                    {
                        TaskSchedule = taskSchedule,
                        Date = taskSchedule.StartDate.AddDays(x)
                    }));
        }
        else if (taskSchedule.Frequency == Frequency.Weekly)
        {
            occurrencesToCreate.AddRange(
                Enumerable.Range(0, numberOfOccurrences)
                    .Select(x => new TaskOccurrence
                    {
                        TaskSchedule = taskSchedule,
                        Date = taskSchedule.StartDate.AddDays(x * 7)
                    }));
        }
        else if (taskSchedule.Frequency == Frequency.Monthly)
        {
            occurrencesToCreate.AddRange(
                Enumerable.Range(0, numberOfOccurrences)
                    .Select(x => new TaskOccurrence
                    {
                        TaskSchedule = taskSchedule,
                        Date = taskSchedule.StartDate.AddMonths(x)
                    }));
        }
        else if (taskSchedule.Frequency == Frequency.Yearly)
        {
            occurrencesToCreate.AddRange(
                Enumerable.Range(0, numberOfOccurrences)
                    .Select(x => new TaskOccurrence
                    {
                        TaskSchedule = taskSchedule,
                        Date = taskSchedule.StartDate.AddYears(x)
                    }));
        }
        else if (taskSchedule.Frequency == Frequency.Custom)
        {
            DayOfWeek[] daysOfTheWeek = taskSchedule.DaysOfTheWeek ?? (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek));
            // Performance optimization to prevent search on each iteration
            Dictionary<DayOfWeek, bool> repeatOnDay = new();
            foreach (var day in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
            {
                repeatOnDay[day] = daysOfTheWeek.Any(x => x == day);
            }
            // Null default means it inherits from schedule
            var timesOfTheDay = taskSchedule.TimesOfTheDay?.Select(x => (TimeOnly?)x)
                ?? new TimeOnly?[] { null };

            for (int i = 0; i < numberOfOccurrences * 7; i++)
            {
                var occurrenceDate = taskSchedule.StartDate.AddDays(i);
                if (!repeatOnDay[occurrenceDate.DayOfWeek]) continue;

                foreach (var time in timesOfTheDay)
                {
                    occurrencesToCreate.Add(new TaskOccurrence
                    {
                        TaskSchedule = taskSchedule,
                        Date = occurrenceDate,
                        StartTime = time
                    });
                }
            }
        }

        if (taskSchedule.NumberOfOccurrences != null
            && occurrencesToCreate.Count > taskSchedule.NumberOfOccurrences)
        {
            occurrencesToCreate = occurrencesToCreate.Take(taskSchedule.NumberOfOccurrences.Value).ToList();
        }

        if (taskSchedule.EndDate != null)
        {
            occurrencesToCreate = occurrencesToCreate.Where(x => x.Date <= taskSchedule.EndDate).ToList();
        }

        _context.TaskOccurrences.AddRange(occurrencesToCreate);
    }

    public IEnumerable<TaskSchedule> GetAll()
    {
        return _context.TaskSchedules.ToList();
    }

    public TaskSchedule? Get(int id)
    {
        return _context.TaskSchedules.SingleOrDefault(e => e.Id == id);
    }

    public void Update(TaskSchedule task)
    {
        _context.TaskSchedules.Update(task);
    }

    public void Delete(int id)
    {
        var entity = _context.TaskSchedules.SingleOrDefault(x => x.Id == id)
            ?? throw new KeyNotFoundException();

        _context.TaskSchedules.Remove(entity);
    }
}