using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class UserCourse
{
    public Guid UserId { get; set; }
    public virtual AppUser? User { get; set; }
    
    public Guid CourseId { get; set; }
    public virtual Course? Course { get; set; }
    public string? Role { get; set; }
}