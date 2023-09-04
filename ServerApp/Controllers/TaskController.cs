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

    [HttpGet("{id}")]
    public FamilyTask GetById(int id)
    {
        return _taskService.Get(id) ?? throw new KeyNotFoundException($"{id}");
    }

    [HttpPost]
    public FamilyTask Create(FamilyTask task)
    {
        return _taskService.Create(task);
    }

    [HttpPut]
    public void Update(FamilyTask task)
    {
        _taskService.Update(task);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _taskService.Delete(id);
    }
}
