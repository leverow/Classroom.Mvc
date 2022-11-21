using Classroom.Mvc.Entities;

namespace Classroom.Mvc.Models;

public class UserTask
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public EUserTaskStatus Status { get; set; }
}