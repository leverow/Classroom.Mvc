using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class AppTask
{
    public Guid Id { get; set; }
    
    public Guid CourseId { get; set; }
    [ForeignKey(nameof(CourseId))]
    public virtual Course? Course { get; set; }

    public ETaskStatus Status { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public ushort MaxScore { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual List<UserTask>? UserTasks { get; set; }
    public virtual List<TaskComment>? Comments { get; set; }
}