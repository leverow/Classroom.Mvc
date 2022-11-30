using Classroom.Mvc.Models;
using Classroom.Mvc.Repository;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Classroom.Mvc.Services;

public class AppTaskService : IAppTaskService
{
    private readonly ILogger<AppTaskService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Entities.AppUser> _userManager;

    public AppTaskService(
        ILogger<AppTaskService> logger,
        IUnitOfWork unitOfWork,
        UserManager<Entities.AppUser> userManager)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }
    public async Task<Result<AppTask>> CreateAsync(AppTask model, ClaimsPrincipal userClaimsPrincipal)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        if (string.IsNullOrWhiteSpace(model.Title))
            return new("Title is invalid");

        var course = await _unitOfWork.Courses.GetAll().FirstOrDefaultAsync(c => c.Id == model.CourseId);
        if (course is null)
            return new("Course with given id not found.");

        var user = await _userManager.GetUserAsync(userClaimsPrincipal);

        if (course.UserCourses?.Any(uc => uc.UserId == user.Id && HasUserGotAccess(uc.Role)) != true)
            return new("Sorry! You have no access to add the task.");

        var task = model.Adapt<Entities.AppTask>();

        try
        {
            task.CreatedDate = DateTime.UtcNow;
            task.CourseId = model.CourseId;

            await _unitOfWork.Tasks.AddAsync(task);

            return new(true);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new("Couldn't create task. Contact support.", exception);
        }
    }

    public async Task<bool> Exists(Guid courseId, Guid taskId)
    {
        var existedAppTaskResult = await GetTaskByIdAsync(courseId, taskId);
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

    public async Task<Result<Entities.AppTask>> GetTaskByIdAsync(Guid courseId, Guid taskId)
    {
        try
        {
            var existingAppTask = await _unitOfWork.Tasks.GetAll().FirstOrDefaultAsync(s => s.Id == taskId && s.CourseId == courseId);
            if (existingAppTask is null)
                return new("Task with given id not found.");

            return new(true) { Data = existingAppTask };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new($"Couldn't get task. Contact support.", exception);
        }
    }

    public async Task<Result<AppTask>> RemoveByIdAsync(Guid courseId, Guid taskId)
    {
        try
        {
            var existingAppTask = _unitOfWork.Tasks.GetAll().FirstOrDefault(t => t.Id == taskId && t.CourseId == courseId);
            if (existingAppTask is null)
                return new("Task with given id not found.");

            var removedResult = await _unitOfWork.Tasks.RemoveAsync(existingAppTask);
            if (removedResult is null)
                return new("Removing the task failed. Contact support.");

            return new(true) { Data = removedResult.Adapt<Models.AppTask>() };
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error occured at {nameof(AppTaskService)}", exception);
            throw new("Couldn't remove the task. Contact support.", exception);
        }
    }

    public async Task<Result<AppTask>> UpdateAsync(AppTask model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        if (string.IsNullOrWhiteSpace(model.Title))
            return new("Title is invalid");

        var existingAppTask = _unitOfWork.Tasks.GetAll().FirstOrDefault(t => t.Id == model.Id && t.CourseId == model.CourseId);
        if (existingAppTask is null)
            return new("Task not found.");

        existingAppTask.Title = model.Title;
        existingAppTask.CourseId = model.CourseId;
        existingAppTask.Description = model.Description;
        existingAppTask.StartDate = model.StartDate;
        existingAppTask.EndDate = model.EndDate;
        existingAppTask.CreatedDate = model.CreatedDate;
        existingAppTask.MaxScore = model.MaxScore;
        existingAppTask.Status = model.Status;

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
    private bool HasUserGotAccess(string? role)
    {
        if (string.IsNullOrWhiteSpace(role))
            return false;

        if (role.Contains("owner") || role.Contains("teacher"))
            return true;

        return false;
    }
}