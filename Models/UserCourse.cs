namespace Classroom.Mvc.Models;

public class UserCourse
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
    public string? Role { get; set; }
}