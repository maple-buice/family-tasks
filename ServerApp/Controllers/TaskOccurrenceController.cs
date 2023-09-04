using family_tasks.Repository.Models;
using family_tasks.Services;
using Microsoft.AspNetCore.Mvc;
using static family_tasks.Services.TaskOccurrenceService;

namespace family_tasks.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskOccurrenceController : ControllerBase
{
    private readonly ILogger<TaskOccurrenceController> _logger;

    private readonly TaskOccurrenceService _taskOccurrenceService;

    public TaskOccurrenceController(
        ILogger<TaskOccurrenceController> logger,
        TaskOccurrenceService taskOccurrenceService)
    {
        _logger = logger;
        _taskOccurrenceService = taskOccurrenceService;
    }

    [HttpGet]
    public IEnumerable<TaskOccurrence> Get()
    {
        return _taskOccurrenceService.GetFamilyTaskOccurrences();
    }

    [HttpGet("{id}")]
    public TaskOccurrence GetById(int id)
    {
        return _taskOccurrenceService.GetById(id)
            ?? throw new KeyNotFoundException();
    }

    [HttpPut]
    public void Update(
        TaskOccurrence taskEvent,
        [FromQuery] Scope scope = Scope.Single)
    {
        _taskOccurrenceService.Update(taskEvent, scope);
    }

    [HttpDelete("{id}")]
    public void Delete(
        int id,
        [FromQuery] Scope scope = Scope.Single)
    {
        _taskOccurrenceService.Delete(id, scope);
    }
}