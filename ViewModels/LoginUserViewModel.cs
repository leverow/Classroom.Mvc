using System.ComponentModel.DataAnnotations;

namespace Classroom.Mvc.ViewModels;

public class LoginUserViewModel
{
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string Password { get; set; }

    public string? ReturnUrl { get; set; }
}