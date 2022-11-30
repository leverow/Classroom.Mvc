using Classroom.Mvc.Entities;

namespace Classroom.Mvc.ViewModels;

public class TaskCommentViewModel
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid? ParentId { get; set; }
    public TaskComment? Parent { get; set; }
    public List<TaskComment>? Children { get; set; }
    public Guid TaskId { get; set; }
    public virtual AppTask? Task { get; set; }
    public Guid UserId { get; set; }
    public virtual AppUser? User { get; set; }
}