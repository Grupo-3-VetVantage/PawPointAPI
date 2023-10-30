using System.ComponentModel.DataAnnotations;

namespace PawPoint.API.Input;

public class SignupVetInput
{
    [Required]
    [MaxLength(60)]
    [MinLength(1)]
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}