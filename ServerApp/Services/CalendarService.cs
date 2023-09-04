using family_tasks.Repositories;
using family_tasks.Services.Models;

namespace family_tasks.Services;

public class CalendarService
{
    private readonly TaskContext _context;

    public CalendarService(TaskContext context)
    {
        _context = context;
    }

    public MonthOfTasks GetMonth(int offset = 0)
    {
        var offsetDate = DateOnly.FromDateTime(DateTime.Now).AddMonths(offset);

        return new MonthOfTasks
        {
            Month = offsetDate.Month,
            Year = offsetDate.Year,
            Days = _context.TaskOccurrences
            .Where(x =>
                x.Date.Month == offsetDate.Month
                && x.Date.Year == offsetDate.Year)
            .GroupBy(x => x.Date)
            .Select(x => new DayOfTasks
            {
                Day = x.Key,
                Tasks = x.ToList()
            })
            .ToList()
        };
    }

    public WeekOfTasks GetWeek(int offset = 0)
    {
        var offsetDate = DateOnly.FromDateTime(DateTime.Now).AddDays(offset * 7);
        var firstDayOfWeek = offsetDate.AddDays(-(int)offsetDate.DayOfWeek);
        var lastDayOfWeek = offsetDate.AddDays(7 - (int)offsetDate.DayOfWeek);

        return new WeekOfTasks
        {
            FirstDayOfWeek = firstDayOfWeek,
            LastDayOfWeek = lastDayOfWeek,
            Days = _context.TaskOccurrences
            .Where(x =>
                x.Date >= firstDayOfWeek
                && x.Date <= lastDayOfWeek)
            .GroupBy(x => x.Date)
            .Select(x => new DayOfTasks
            {
                Day = x.Key,
                Tasks = x.ToList()
            })
            .ToList()
        };
    }

    public DayOfTasks GetDay(int offset = 0)
    {
        var offsetDate = DateOnly.FromDateTime(DateTime.Now).AddDays(offset);

        return new DayOfTasks
        {
            Day = offsetDate,
            Tasks = _context.TaskOccurrences
                .Where(x => x.Date == offsetDate).ToList()
        };
    }
}