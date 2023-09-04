using family_tasks.Repository.Models;
using family_tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace family_tasks.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;

    private readonly CategoryService _categoryService;

    public CategoryController(ILogger<CategoryController> logger, CategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet]
    public IEnumerable<Category> Get()
    {
        return _categoryService.GetAll();
    }

    [HttpGet("{id}")]
    public Category GetById(int id)
    {
        return _categoryService.Get(id) ?? throw new KeyNotFoundException($"{id}");
    }

    [HttpPost]
    public Category Create(Category category)
    {
        return _categoryService.Create(category);
    }

    [HttpPut]
    public void Update(Category category)
    {
        _categoryService.Update(category);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _categoryService.Delete(id);
    }
}
