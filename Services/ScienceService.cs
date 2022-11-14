using Classroom.Mvc.Models;
using Classroom.Mvc.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Mvc.Services;

public class ScienceService : IScienceService
{
    private readonly ILogger<ScienceService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ScienceService(
        ILogger<ScienceService> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Science>> CreateAsync(Science model)
    {
        if (model is null) throw new ArgumentNullException(nameof(model));

        if (string.IsNullOrWhiteSpace(model.Name)) return new("Name is invalid");

        var retrievedScience = _unitOfWork.Sciences.GetAll().FirstOrDefault(s => s.Name == model.Name);
        if (retrievedScience != null) return new("Science already exists");

        var entity = model.Adapt<Entities.Science>();

        try
        {
            entity.CreatedAt = DateTime.UtcNow;
            var createdScience = await _unitOfWork.Sciences.AddAsync(entity);
            return new(true) { Data = createdScience.Adapt<Models.Science>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(ScienceService)}", exception);
            throw new("Couldn't create science. Contact support.", exception);
        }
    }

    public async Task<bool> Exists(Guid id)
    {
        var existedScienceResult = await GetScienceByIdAsync(id);
        return existedScienceResult.IsSuccess;
    }

    public async Task<Result<IEnumerable<Science>>> GetAllSciencesAsync()
    {
        var existingSciences = _unitOfWork.Sciences.GetAll();
        if (existingSciences is null) return new("No sciences found.");

        try
        {
            var selectedSciences = await existingSciences.Select(s => s.Adapt<Models.Science>()).ToListAsync();
            return new(true) { Data = selectedSciences };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(ScienceService)}", exception);
            throw new($"Couldn't get sciences. Contact support.", exception);
        }
    }

    public async Task<Result<Science>> GetScienceByIdAsync(Guid id)
    {
        try
        {
            var existingScience = await _unitOfWork.Sciences.GetAll().FirstOrDefaultAsync(s => s.Id == id);
            if (existingScience is null) return new("Science with given id not found.");

            return new(true) { Data = existingScience.Adapt<Models.Science>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(ScienceService)}", exception);
            throw new($"Couldn't get science. Contact support.", exception);
        }
    }

    public async Task<Result<Science>> RemoveByIdAsync(Guid id)
    {
        try
        {
            var existingScience = _unitOfWork.Sciences.GetById(id);
            if (existingScience is null) return new("Science with given id not found.");

            var removedResult = await _unitOfWork.Sciences.RemoveAsync(existingScience);
            if (removedResult is null) return new("Removing the science failed. Contact support.");

            return new(true) { Data = removedResult.Adapt<Models.Science>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(ScienceService)}", exception);
            throw new("Couldn't remove the Science. Contact support.", exception);
        }
    }

    public async Task<Result<Science>> UpdateAsync(Guid id, Science model)
    {
        if (model is null) throw new ArgumentNullException(nameof(model));

        if (string.IsNullOrWhiteSpace(model.Name)) return new("Name is invalid");

        var existingScience = _unitOfWork.Sciences.GetById(id);
        if (existingScience is null) return new("Science not found.");

        try
        {
            var updatedScience = await _unitOfWork.Sciences.UpdateAsync(existingScience);
            if (updatedScience is null) return new("Updating science failed.");

            return new(true) { Data = updatedScience.Adapt<Models.Science>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(ScienceService)}", exception);
            throw new("Couldn't update the science. Contact support.", exception);
        }
    }
}