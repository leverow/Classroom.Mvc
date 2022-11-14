using Classroom.Mvc.Models;

namespace Classroom.Mvc.Services;

public interface IScienceService
{
    Task<Result<Science>> CreateAsync(Science model);
    Task<Result<IEnumerable<Science>>> GetAllSciencesAsync();
    Task<Result<Science>> GetScienceByIdAsync(Guid id);
    Task<Result<Science>> UpdateAsync(Guid id, Science model);
    Task<Result<Science>> RemoveByIdAsync(Guid id);
    Task<bool> Exists(Guid id);
}