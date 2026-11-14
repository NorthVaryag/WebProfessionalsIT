using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProfessionalsIT.Context;
using WebProfessionalsIT.DTO;
using WebProfessionalsIT.Entities;

namespace WebProfessionalsIT;

[Route("api/[controller]")]
[ApiController]
public class SkillsController : ControllerBase
{
    private readonly MyDbContext _context;
    public SkillsController(MyDbContext context)
    {
        _context = context;
    }
    //Get All
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills()
    {
        var skills = await _context.Skills.AsNoTracking().Select(s => new SkillDTO
        {
            Id = s.Id,
            Tehnology = s.Tehnology,
            Level = s.Level,
        }).ToListAsync();
        return Ok(skills);
    }
    
    //Get to id
    [HttpGet("{id}")]
    public async Task<ActionResult<SkillDTO>> GetSkill(int id)
    {
        var skill = await _context.Skills.FindAsync(id);
        if (skill == null)
            return NotFound(new { message = "Навык не найден" });
        return Ok( new SkillDTO
        {
            Id = skill.Id,
            Tehnology = skill.Tehnology,
            Level = skill.Level,
        });
    }
    
    //добавить навык в каталог
    [HttpPost]
    public async Task<IActionResult> CreateSkill(CreateSkillDTO dto)
    {
        
    }
}