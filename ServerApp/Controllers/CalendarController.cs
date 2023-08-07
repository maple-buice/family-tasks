using family_tasks.Services.Models;
using family_tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace family_tasks.Controllers;

[ApiController]
[Route("[controller]")]
public class CalendarController : ControllerBase
{
    private readonly ILogger<CalendarController> _logger;

    private readonly CalendarService _calendarService;

    public CalendarController(
        ILogger<CalendarController> logger,
        CalendarService calendarService)
    {
        _logger = logger;
        _calendarService = calendarService;
    }

    [HttpGet]
    [Route("/month")]
    public MonthOfTasks GetMonth(int offset = 0)
    {
        return _calendarService.GetMonth(offset);
    }

    [HttpGet]
    [Route("/week")]
    public WeekOfTasks GetWeek(int offset = 0)
    {
        return _calendarService.GetWeek(offset);
    }

    [HttpGet]
    [Route("/day")]
    public DayOfTasks GetDay(int offset = 0)
    {
        return _calendarService.GetDay(offset);
    }
}