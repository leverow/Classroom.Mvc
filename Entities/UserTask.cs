using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class UserTask
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual AppUser? User { get; set; }

    public Guid TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public virtual AppTask? Task { get; set; }

    public string? Description { get; set; }
    public EUserTaskStatus Status { get; set; }
}