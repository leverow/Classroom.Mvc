namespace Classroom.Mvc.Models;

public class TaskComment
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid? ParentId { get; set; }
    public virtual TaskComment? Parent { get; set; }
    public virtual List<TaskComment>? Children { get; set; }
    public Guid TaskId { get; set; }
    public virtual AppTask? Task { get; set; }
    public Guid UserId { get; set; }
    public virtual AppUser? User { get; set; }
}
