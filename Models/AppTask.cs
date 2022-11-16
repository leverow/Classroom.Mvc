namespace Classroom.Mvc.Models;

public class AppTask
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public uint Status { get; set; }
    public string? Description { get; set; }
    public string Title { get; set; }
    public string? Url { get; set; }
    public ushort MaxScore { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}