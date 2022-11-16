using System.ComponentModel.DataAnnotations;

namespace Classroom.Mvc.ViewModels;

public class JoinCourseViewModel
{
    [Required]
    public string? SecretKey { get; set; }
}