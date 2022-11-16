using System.ComponentModel.DataAnnotations.Schema;

namespace Classroom.Mvc.Entities;

public class AppTask
{
    public Guid Id { get; set; }
    
    public Guid ScienceId { get; set; }
    [ForeignKey("ScienceId")]
    public virtual Course? Science { get; set; }

    public uint Status { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
    public ushort MaxScore { get; set; }
    public decimal CreatedDate { get; set; }
    public decimal StartDate { get; set; }
    public DateTime EndDate { get; set; }
}