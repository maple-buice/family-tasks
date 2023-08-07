using family_tasks.Repository.Models;
using family_tasks.Repositories;

namespace family_tasks.Services;

public class CategoryService
{
    private readonly TaskContext _context;

    public CategoryService(TaskContext context)
    {
        _context = context;
    }

    public Category Create(Category task) {
        _context.Categories.Add(task);
        // TODO: Verify that this sets the Id by reference
        return task;
    }

    public IEnumerable<Category> GetAll()
    {
        return _context.Categories.ToList();
    }

    public Category? Get(int id) {
        return _context.Categories.SingleOrDefault(e => e.Id == id);
    }

    public void Update(Category task) {
        _context.Categories.Update(task);
    }

    public void Delete(int id) {
        _context.Remove(id);
    }
}