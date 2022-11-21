using Classroom.Mvc.Entities;
using System.ComponentModel.DataAnnotations;

namespace Classroom.Mvc.ViewModels;

public class UpdateTaskViewModel
{
    [Required]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ushort MaxScore { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ETaskStatus Status { get; set; }

    [Required]
    public Guid CourseId { get; set; }
    [Required]
    public Guid TaskId { get; set; }
}