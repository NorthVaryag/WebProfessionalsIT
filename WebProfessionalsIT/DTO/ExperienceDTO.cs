using System.ComponentModel.DataAnnotations;

namespace WebProfessionalsIT.DTO;

public class ExperienceDTO
{
    public int Id { get; set; }
    public int? EmploymentType { get; set; }

    public string? Company { get; set; }

    public string? PositionJob { get; set; }

    public DateOnly? StartWork { get; set; }

    public DateOnly? EndWork { get; set; }

    public int User { get; set; }
}

public class CreateExperienceDTO
{
    public int? EmploymentType { get; set; }
    [MaxLength(100)]
    public string? Company { get; set; }
    [MaxLength(100)]
    public string? PositionJob { get; set; }
    public DateOnly? StartWork { get; set; }
    public DateOnly? EndWork { get; set; }
    [Required]
    public int User { get; set; }
}

public class UpdateExperienceDTO : CreateExperienceDTO
{
    
}