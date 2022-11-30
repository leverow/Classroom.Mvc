using System.ComponentModel.DataAnnotations;

namespace Classroom.Mvc.ViewModels;

public class CreateTaskCommentViewModel
{
    [Required]
    public string? Message { get; set; }
    public Guid? ParentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid TaskId { get; set; }
}