using Classroom.Mvc.Models;
using System.Security.Claims;

namespace Classroom.Mvc.Services;

public interface IAppTaskService
{
    Task<Result<AppTask>> CreateAsync(AppTask model, ClaimsPrincipal claimsPrincipal);
    Task<Result<IEnumerable<AppTask>>> GetAllTasksAsync();
    Task<Result<AppTask>> GetTaskByIdAsync(Guid courseId, Guid taskId);
    Task<Result<AppTask>> UpdateAsync(AppTask model);
    Task<Result<AppTask>> RemoveByIdAsync(Guid courseId, Guid taskId);
    Task<bool> Exists(Guid courseId, Guid id);
}