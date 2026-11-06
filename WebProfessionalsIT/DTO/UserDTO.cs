using System.ComponentModel.DataAnnotations;

namespace WebProfessionalsIT.DTO;

public class UserDTO
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(75)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string? Surname { get; set; }
    
    [EmailAddress]
    [MaxLength(75)]
    public string? Email { get; set; }
    public int? NumberPhone { get; set; }
    public string? Role { get; set; }
    
    public class UpdateUserDTO
    {
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? Surname { get; set; }
        
        [EmailAddress]
        [MaxLength(75)]
        public string? Email { get; set; }
        public int? NumberPhone { get; set; }
    }
}