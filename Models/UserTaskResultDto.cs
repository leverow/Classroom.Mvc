using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Models;

public class UserTaskResultDto : AppTask
{
    public UserTaskResult? UserResult { get; set; }
}
public class UserTaskResult
{
    public string? Description { get; set; }
    public EUserTaskStatus Status { get; set; }
}