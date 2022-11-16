namespace Classroom.Mvc.ViewModels;

public class CreateTaskViewModel
{
    public string? Description { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
    public ushort MaxScore { get; set; }
    public decimal StartDate { get; set; }
    public DateTime EndDate { get; set; }
}