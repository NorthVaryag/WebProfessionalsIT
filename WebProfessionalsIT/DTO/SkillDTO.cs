using System.ComponentModel.DataAnnotations;

namespace WebProfessionalsIT.DTO;

public class SkillDTO
{
    public int Id { get; set; }
    public int Tehnology { get; set; }
    public int Level { get; set; }
}

public class CreateSkillDTO
{
    [Required]
    public int Tehnology { get; set; }
    [Required]
    public int Level { get; set; }
}

public class UserSkillDTO
{
    public int Id { get; set; }
    public int User { get; set; }
    public int? Skill { get; set; }
}
public class CreateUserSkillDTO
{
    [Required]
    public int User { get; set; }
    [Required]
    public int Skill { get; set; }
}