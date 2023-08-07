using family_tasks.Repository.Models;
using family_tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace family_tasks.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    private readonly TaskService _taskService;

    public TaskController(ILogger<TaskController> logger, TaskService taskService)
    {
        _logger = logger;
        _taskService = taskService;
    }

    [HttpGet]
    public IEnumerable<FamilyTask> Get()
    {
        return _taskService.GetAll();
    }
}
