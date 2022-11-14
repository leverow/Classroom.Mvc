using Microsoft.AspNetCore.Identity;

namespace Classroom.Mvc.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long ChatId { get; set; }
    public ushort Step { get; set; }
    public string? PhotoUrl { get; set; }
    public EUserStatus Status { get; set; }
}