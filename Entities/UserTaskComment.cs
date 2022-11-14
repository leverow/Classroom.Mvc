using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class UserTaskComment
{
    public Guid Id { get; set; }
    public string? Message { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual AppUser? User { get; set; }

    public Guid UserTaskId { get; set; }
    [ForeignKey("UserTaskId")]
    public virtual UserTask? UserTask { get; set; }
}