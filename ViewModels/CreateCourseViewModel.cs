using System.ComponentModel.DataAnnotations;

namespace Classroom.Mvc.ViewModels;

public class CreateCourseViewModel
{
    [Required]
    [MinLength(2,ErrorMessage = "Kurs nomida kamida 2ta belgi qatnashishi lozim.")]
    [MaxLength(20, ErrorMessage = "Kurs nomida 20tadan oshiq belgi bo`lmasligi lozim.")]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Audience { get; set; }
}