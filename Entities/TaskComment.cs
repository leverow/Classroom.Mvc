using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class TaskComment
{
    public Guid Id { get; set; }
    
    [Column(TypeName = "nvarchar")]
    public string? Message { get; set; }
    public DateTime? CreatedDate { get; set; }

    public Guid? ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public virtual TaskComment? Parent { get; set; }

    public virtual List<TaskComment>? Children { get; set; }

    public Guid TaskId { get; set; }
    [ForeignKey(nameof(TaskId))]
    public virtual AppTask? Task { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual AppUser? User { get; set; }
}