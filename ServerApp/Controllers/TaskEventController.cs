using family_tasks.Repository.Models;
using family_tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace family_tasks.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskEventController : ControllerBase
{
    private readonly ILogger<TaskEventController> _logger;

    private readonly TaskEventService _taskOccurrenceService;

    public TaskEventController(
        ILogger<TaskEventController> logger,
        TaskEventService taskOccurrenceService)
    {
        _logger = logger;
        _taskOccurrenceService = taskOccurrenceService;
    }

    [HttpGet]
    public IEnumerable<TaskEvent> Get()
    {
        return _taskOccurrenceService.GetFamilyTaskOccurrences();
    }

    [HttpGet("{id}")]
    public TaskEvent GetById(int id)
    {
        return _taskOccurrenceService.GetById(id)
            ?? throw new KeyNotFoundException();
    }
}