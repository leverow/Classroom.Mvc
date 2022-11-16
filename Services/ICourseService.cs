using Classroom.Mvc.Models;

namespace Classroom.Mvc.Services;

public interface ICourseService
{
    Task<Result<Entities.Course>> CreateAsync(Course model, string? ownerName);
    Task<Result<IEnumerable<Entities.Course>>> GetAllCoursesAsync();
    Task<Result<Entities.Course>> GetCourseByIdAsync(Guid id);
    Task<Result<Entities.Course>> GetCourseByKeyAsync(string? secretKey);
    Task<Result<Entities.Course>> UpdateAsync(Guid id, Course model);
    Task<Result<Entities.Course>> RemoveByIdAsync(Guid id);
    Task<bool> Exists(Guid id);
    void Save();
}