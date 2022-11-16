namespace Classroom.Mvc.Models;

public class Course
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Audience { get; set; }
    public string? SecurityKey { get; set; }
    public ECourseStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public uint ImageType { get; set; }
    public Guid CreatedBy { get; set; }
    public AppUser? Owner { get; set; }
    public ICollection<UserCourse>? UserCourses { get; set; }
}