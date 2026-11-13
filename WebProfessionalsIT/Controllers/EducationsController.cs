using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProfessionalsIT.Context;
using WebProfessionalsIT.DTO;
using WebProfessionalsIT.Entities;

namespace WebProfessionalsIT;

[Route("api/[controller]")]
[ApiController]
public class EducationsController : ControllerBase
{
    private readonly MyDbContext  _context;
    public EducationsController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet] //получить все
    public async Task<ActionResult<IEnumerable<EducationDTO>>> GetEducations()
    {
        var result = await _context.Educations.AsNoTracking()
            .Select(e => new
                EducationDTO
                {
                    Id = e.Id,
                    TypeEducations = e.TypeEducations,
                    InstitutionName = e.InstitutionName,
                    StartEducation = e.StartEducation,
                    EndEducation = e.EndEducation,
                    ResultEducation = e.ResultEducation,
                    User = e.User
                }).ToListAsync();
        return Ok(result);
    }

    //получить образование пользователя
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<EducationDTO>>> GetUserEducation(int userId)
    {
        var result = await _context.Educations.AsNoTracking()
            .Where(e => e.User == userId).Select(e => new EducationDTO
            {
                Id = e.Id,
                TypeEducations = e.TypeEducations,
                InstitutionName = e.InstitutionName,
                StartEducation = e.StartEducation,
                EndEducation = e.EndEducation,
                ResultEducation = e.ResultEducation,
                User = e.User
                
            }).ToListAsync();
        return Ok(result);
    }
    
    //Получить запись по ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEducation(int id)
    {
        var education = await _context.Educations.FindAsync(id);

        if (education == null)
            return NotFound(new { message = "Образование не найдено" });
        
        return Ok(new EducationDTO
        {
            Id = education.Id,
            TypeEducations = education.TypeEducations,
            InstitutionName = education.InstitutionName,
            StartEducation = education.StartEducation,
            EndEducation = education.EndEducation,
            ResultEducation = education.ResultEducation,
            User = education.User
        });
    }

    //Добавление образования
    [HttpPost]
    public async Task<ActionResult<EducationDTO>> PostEducation(CreateEducationDTO dto)
    {
        if (
            dto.StartEducation.HasValue &&
            dto.EndEducation.HasValue &&
            dto.EndEducation < dto.StartEducation)
        {
            return BadRequest(new { message = "Дата окончания раньше даты начала" });
        }

        var education = new Education
        {
            TypeEducations = dto.TypeEducations,
            InstitutionName = dto.InstitutionName,
            StartEducation = dto.StartEducation,
            EndEducation = dto.EndEducation,
            ResultEducation = dto.ResultEducation,
            User = dto.User
        };
        _context.Educations.Add(education);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(
            nameof(GetEducation),
            new { id = education.Id },
            new { id = education.Id, message = "Образование не добавлено" });
    }
    
    //Изменить образование
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEducation(int id, CreateEducationDTO dto)
    {
        var education = await _context.Educations.FindAsync(id);

        if (education == null)
            return NotFound(new { message = "Образование не найдено" });
        
        if (dto.StartEducation.HasValue && 
            dto.EndEducation.HasValue && 
            dto.EndEducation < education.StartEducation)
        {
            return BadRequest(new { message = "Дата окончания раньше даты начала" });
        }
        
        education.TypeEducations = dto.TypeEducations;
        education.InstitutionName = dto.InstitutionName;
        education.StartEducation = dto.StartEducation;
        education.EndEducation = dto.EndEducation;
        education.ResultEducation = dto.ResultEducation;
        education.User = dto.User;
        
        await _context.SaveChangesAsync();
        return Ok(new { message = "Образование обновлено" });
    }
    
    //Удаление
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEducation(int id)
    {
        var education = await _context.Educations.FindAsync(id);

        if (education == null)
            return NotFound(new { message = "Образование не найдено" });

        _context.Educations.Remove(education);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Образование удалено" });
    }
}