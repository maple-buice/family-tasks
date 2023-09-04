using family_tasks.Repository.Models;
using family_tasks.Repositories;

namespace family_tasks.Services;

public class FamilyMemberService
{
    private readonly TaskContext _context;

    public FamilyMemberService(TaskContext context)
    {
        _context = context;
    }

    public FamilyMember Create(FamilyMember task)
    {
        _context.FamilyMembers.Add(task);
        // TODO: Verify that this sets the Id by reference
        return task;
    }

    public IEnumerable<FamilyMember> GetAll()
    {
        return _context.FamilyMembers.ToList();
    }

    public FamilyMember? Get(int id)
    {
        return _context.FamilyMembers.SingleOrDefault(e => e.Id == id);
    }

    public void Update(FamilyMember task)
    {
        _context.FamilyMembers.Update(task);
    }

    public void Delete(int id)
    {
        _context.Remove(id);
    }
}