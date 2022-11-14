namespace Classroom.Mvc.Models;

public class Science
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public EScienceStatus Status { get; set; }
    public Guid SchoolId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
}