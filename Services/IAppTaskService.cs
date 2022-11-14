using Classroom.Mvc.Models;

namespace Classroom.Mvc.Services;

public interface IAppTaskService
{
    Task<Result<AppTask>> CreateAsync(AppTask model);
    Task<Result<IEnumerable<AppTask>>> GetAllTasksAsync();
    Task<Result<AppTask>> GetTaskByIdAsync(Guid id);
    Task<Result<AppTask>> UpdateAsync(Guid id, AppTask model);
    Task<Result<AppTask>> RemoveByIdAsync(Guid id);
    Task<bool> Exists(Guid id);
}