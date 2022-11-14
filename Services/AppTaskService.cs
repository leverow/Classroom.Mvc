using Classroom.Mvc.Models;
using Classroom.Mvc.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Mvc.Services;

public class AppTaskService : IAppTaskService
{
    private readonly ILogger<AppTaskService> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AppTaskService(
        ILogger<AppTaskService> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<AppTask>> CreateAsync(AppTask model)
    {
        if (model is null) throw new ArgumentNullException(nameof(model));

        if (string.IsNullOrWhiteSpace(model.Title)) return new("Title is invalid");

        var retrievedAppTask = _unitOfWork.Tasks.GetAll().FirstOrDefault(s => s.Title == model.Title);
        if (retrievedAppTask != null) return new("Task already exists");

        var entity = model.Adapt<Entities.AppTask>();

        try
        {
            entity.CreatedDate = DateTimeOffset.Now.ToUnixTimeSeconds();
            entity.StartDate = DateTimeOffset.Now.ToUnixTimeSeconds();

            var createdAppTask = await _unitOfWork.Tasks.AddAsync(entity);
            return new(true) { Data = createdAppTask.Adapt<Models.AppTask>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new("Couldn't create task. Contact support.", exception);
        }
    }

    public async Task<bool> Exists(Guid id)
    {
        var existedAppTaskResult = await GetTaskByIdAsync(id);
        return existedAppTaskResult.IsSuccess;
    }

    public async Task<Result<IEnumerable<AppTask>>> GetAllTasksAsync()
    {
        var existingAppTasks = _unitOfWork.Tasks.GetAll();
        if (existingAppTasks is null) return new("No tasks found.");

        try
        {
            var selectedAppTasks = await existingAppTasks.Select(s => s.Adapt<Models.AppTask>()).ToListAsync();
            return new(true) { Data = selectedAppTasks };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new($"Couldn't get tasks. Contact support.", exception);
        }
    }

    public async Task<Result<AppTask>> GetTaskByIdAsync(Guid id)
    {
        try
        {
            var existingAppTask = await _unitOfWork.Tasks.GetAll().FirstOrDefaultAsync(s => s.Id == id);
            if (existingAppTask is null) return new("Task with given id not found.");

            return new(true) { Data = existingAppTask.Adapt<Models.AppTask>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new($"Couldn't get task. Contact support.", exception);
        }
    }

    public async Task<Result<AppTask>> RemoveByIdAsync(Guid id)
    {
        try
        {
            var existingAppTask = _unitOfWork.Tasks.GetById(id);
            if (existingAppTask is null) return new("Task with given id not found.");

            var removedResult = await _unitOfWork.Tasks.RemoveAsync(existingAppTask);
            if (removedResult is null) return new("Removing the task failed. Contact support.");

            return new(true) { Data = removedResult.Adapt<Models.AppTask>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new("Couldn't remove the task. Contact support.", exception);
        }
    }

    public async Task<Result<AppTask>> UpdateAsync(Guid id, AppTask model)
    {
        if (model is null) throw new ArgumentNullException(nameof(model));

        if (string.IsNullOrWhiteSpace(model.Title)) return new("Title is invalid");

        var existingAppTask = _unitOfWork.Tasks.GetById(id);
        if (existingAppTask is null) return new("AppTask not found.");

        try
        {
            var updatedAppTask = await _unitOfWork.Tasks.UpdateAsync(existingAppTask);
            if (updatedAppTask is null) return new("Updating task failed.");

            return new(true) { Data = updatedAppTask.Adapt<Models.AppTask>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new("Couldn't update task. Contact support.", exception);
        }
    }
}