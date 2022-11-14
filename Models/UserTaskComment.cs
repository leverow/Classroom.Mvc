namespace Classroom.Mvc.Models;

public class UserTaskComment
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public Guid UserId { get; set; }
    public Guid UserTaskId { get; set; }
}
