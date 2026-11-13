using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProfessionalsIT.Context;
using WebProfessionalsIT.DTO;
using WebProfessionalsIT.Entities;

namespace WebProfessionalsIT;

[Route("api/[controller]")]
[ApiController]
public class ExperiencesController : ControllerBase
{
    private readonly MyDbContext _context;
    public ExperiencesController(MyDbContext context)
    {
        _context = context;
    }
    
    //Получение всего
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExperienceDTO>>> GetExperiences()
    {
        var result = await _context.Experiences.AsNoTracking().Select(e => new ExperienceDTO
        {
            Id = e.Id,
            EmploymentType = e.EmploymentType,
            Company = e.Company,
            PositionJob = e.PositionJob,
            StartWork = e.StartWork,
            EndWork = e.EndWork,
            User = e.User
        }).ToListAsync();
        return Ok(result);
    }
    
    //получение по пользователю
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<ExperienceDTO>>> GetUserExperiences(int userId)
    {
        var result = await _context.Experiences.AsNoTracking().Where(e => e.User == userId).Select(e =>
            new ExperienceDTO
            {
                Id = e.Id,
                EmploymentType = e.EmploymentType,
                Company = e.Company,
                PositionJob = e.PositionJob,
                StartWork = e.StartWork,
                EndWork = e.EndWork,
                User = e.User
            }).ToListAsync();
        
        return Ok(result);
    }
    
    //Получение записи по ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ExperienceDTO>> GetExperience(int id)
    {
        var e = await _context.Experiences.FindAsync(id);

        if (e == null)
            return NotFound(new { message = "Опыт не найден" });
        return Ok(new ExperienceDTO
        {
            Id = e.Id,
                EmploymentType = e.EmploymentType,
                Company = e.Company,
                PositionJob = e.PositionJob,
                StartWork = e.StartWork,
                EndWork = e.EndWork,
                User = e.User
        });
    }
    
    //Добавить опыт работы
    [HttpPost]
    public async Task<ActionResult<ExperienceDTO>> PostExperience(CreateExperienceDTO dto)
    {
        if (dto.StartWork.HasValue &&
            dto.EndWork.HasValue &&
            dto.EndWork < dto.StartWork)
        {
            return BadRequest(new
            {
                message = "ата окончания раньше даты начала"
            });
        }

        var experience = new Experience
        {
            EmploymentType = dto.EmploymentType,
            Company = dto.Company,
            PositionJob = dto.PositionJob,
            StartWork = dto.StartWork,
            EndWork = dto.EndWork,
            User = dto.User
        };
        
        _context.Experiences.Add(experience);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetExperience),
            new { id = experience.Id },
            new { id = experience.Id, message = "Опыт работы добавлен" });
    }
}