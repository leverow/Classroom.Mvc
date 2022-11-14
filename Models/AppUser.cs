namespace Classroom.Mvc.Models;

public class AppUser
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? UserImageUrl { get; set; }
    public IFormFile? UserImage { get; set; }
}