using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class Science
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public EScienceStatus Status { get; set; }
    
    public Guid SchoolId { get; set; }
    [ForeignKey("SchoolId")]
    public virtual School? School { get; set; }

    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    [ForeignKey("CreatedBy")]
    public virtual AppUser? User { get; set; }
}