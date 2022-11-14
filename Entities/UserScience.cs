using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class UserScience
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual AppUser? User { get; set; }
    
    public Guid ScienceId { get; set; }
    [ForeignKey("ScienceId")]
    public virtual Science? Science { get; set; }
}