using Classroom.Mvc.Models;

namespace Classroom.Mvc.Services;

public interface ISchoolService
{
    Task<Result<School>> CreateAsync(School school);
    Task<Result<IEnumerable<School>>> GetAllSchoolsAsync();
    Task<Result<School>> GetSchoolByIdAsync(Guid id);
    Task<Result<School>> UpdateAsync(Guid id, School school);
    Task<Result<School>> RemoveByIdAsync(Guid id);
    Task<bool> Exists(Guid id);
}