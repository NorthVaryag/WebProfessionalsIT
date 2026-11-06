using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProfessionalsIT.Context;
using WebProfessionalsIT.DTO;

namespace WebProfessionalsIT;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly MyDbContext _context;
    public UsersController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUser()
    {
        var users = await _context.Users.Include
            (u => u.RoleNavigation).Select(u => 
            new UserDTO()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Surname = u.Surname,
                Email = u.EMail,
                NumberPhone = u.NumberPhone,
                Role = u.RoleNavigation.Role
            }).FirstOrDefaultAsync();
        if (users == null)
        {
            return NotFound(new {message = "User not found"});
        }
        return Ok(users);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<UserDTO>> UpdateUser(int id, UserDTO.UpdateUserDTO dto)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user == null)
            return NotFound(new {message = "User not found"});

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Surname = dto.Surname;
        user.EMail = dto.Email;
        user.NumberPhone = dto.NumberPhone;

        await _context.SaveChangesAsync();
        
        return Ok(new {message = "User successfully updated"});
    }
}