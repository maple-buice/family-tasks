using family_tasks.Repository.Models;
using family_tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace family_tasks.Controllers;

[ApiController]
[Route("[controller]")]
public class FamilyMemberController : ControllerBase
{
    private readonly ILogger<FamilyMemberController> _logger;

    private readonly FamilyMemberService _familyMemberService;

    public FamilyMemberController(ILogger<FamilyMemberController> logger, FamilyMemberService familyMemberService)
    {
        _logger = logger;
        _familyMemberService = familyMemberService;
    }

    [HttpGet]
    public IEnumerable<FamilyMember> Get()
    {
        return _familyMemberService.GetAll();
    }

    [HttpPost]
    public FamilyMember Create([FromBody] FamilyMember entity)
    {
        return _familyMemberService.Create(entity);
    }

    [HttpPut]
    public void Update([FromBody] FamilyMember entity)
    {
        _familyMemberService.Update(entity);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _familyMemberService.Delete(id);
    }
}
