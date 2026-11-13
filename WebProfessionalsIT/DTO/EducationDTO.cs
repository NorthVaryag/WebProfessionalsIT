using System.ComponentModel.DataAnnotations;

namespace WebProfessionalsIT.DTO;

public class EducationDTO
{
    public int Id { get; set; }
    public int? TypeEducations { get; set; }
    public int? InstitutionName { get; set; }
    public DateOnly? StartEducation { get; set; }
    public DateOnly? EndEducation { get; set; }
    public int? ResultEducation { get; set; }
    public int User { get; set; }
}
public class CreateEducationDTO
{
    public int? TypeEducations { get; set; }
    public int? InstitutionName { get; set; }
    public DateOnly? StartEducation { get; set; }
    public DateOnly? EndEducation { get; set; }
    public int? ResultEducation { get; set; }
    
    [Required]
    public int User { get; set; }
}

public class UpdateEducationDTO : CreateEducationDTO
{
    
}