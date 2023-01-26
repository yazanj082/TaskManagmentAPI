using System.ComponentModel.DataAnnotations;
namespace TasksAPI.Business.Dtos;
public class UserRegistrationDto
{
    
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    
}
