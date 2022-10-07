using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public record TeacherToken
{
    private readonly DateTime _expiresAt;
    
    [Key]
    public Guid Id { get; init; }
    [Required]
    public string Token { get; init; }
    [Required]
    public DateTime ExpiresAt
    {
        get => _expiresAt;
        init => _expiresAt = value.ToUniversalTime();
    }
}