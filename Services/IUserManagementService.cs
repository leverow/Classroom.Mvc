using Classroom.Mvc.Models;

namespace Classroom.Mvc.Services;

public interface IUserManagementService
{
    Task<bool> ExistsAsync(Guid id);
    Task<Result> CreateUserAsync(AppUser model);
    Task<Result<AppUser>> GetUserByIdAsync(Guid id);
    Task<Result<AppUser>> GetUserByUserNameAsync(string? username);
    Task<Result<string>> GetUserPhotoByUserNameAsync(string? username);
    Task<Result> UpdateUserAsync(Guid id, AppUser model);
    Task<Result> DeleteUserByIdAsync(Guid id);
}