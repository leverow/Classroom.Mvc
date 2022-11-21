using Classroom.Mvc.Data;
using Classroom.Mvc.Entities;
using Classroom.Mvc.Models;
using Classroom.Mvc.Repository;
using Classroom.Mvc.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Mvc.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<Entities.AppUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileController(
        UserManager<Entities.AppUser> userManager,
        IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("courses")]
    public async Task<IActionResult> GetCourses()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "User not found");
            return View();
        };
        var userCourseList = user.UserCourses?.ToList();

        return View(new CourseMultipleViewModel() { UserCourse = userCourseList });
    }

    [HttpGet("courses/{courseId}/tasks")]
    public async Task<IActionResult> GetUserTasks(Guid courseId)
    {
        //todo user kursni azosi ekanligini tekshirish kerak
        var user = await _userManager.GetUserAsync(User);

        var course = await _unitOfWork.Courses.GetAll().FirstOrDefaultAsync(c => c.Id == courseId);
        if (course?.Tasks is null)
            return NotFound();

        var tasks = course.Tasks;
        var usertasks = new List<UserTaskResultDto>();

        foreach (var task in tasks)
        {
            var result = task.Adapt<UserTaskResultDto>();
            var userResultEntity = task.UserTasks?.FirstOrDefault(ut => ut.UserId == user.Id);

            result.UserResult = userResultEntity == null ? null : new UserTaskResult()
            {
                Status = userResultEntity.Status,
                Description = userResultEntity.Description
            };

            usertasks.Add(result);
        }

        return Ok(usertasks);
    }

    [HttpGet("courses/{courseId}/tasks/{taskId}/{description}/{status}")]//O'zgartirilishi kerak
    public async Task<IActionResult> AddUserTaskResult([FromRoute] Guid courseId, [FromRoute] Guid taskId, [FromRoute] string? description, [FromRoute]uint status)
    {
        //todo user kursni azosi ekanligini tekshirish kerak

        var task = await _unitOfWork.Tasks.GetAll().FirstOrDefaultAsync(t => t.Id == taskId && t.CourseId == courseId);
        if (task is null)
            return NotFound();

        var user = await _userManager.GetUserAsync(User);

        var userTaskResult = await _unitOfWork.UserTasks.GetAll()
            .FirstOrDefaultAsync(ut => ut.UserId == user.Id && ut.TaskId == taskId);

        if (userTaskResult is null)
        {
            userTaskResult = new Entities.UserTask()
            {
                UserId = user.Id,
                TaskId = taskId
            };

            await _unitOfWork.UserTasks.AddAsync(userTaskResult);
        }

        userTaskResult.Description = description;
        userTaskResult.Status = (EUserTaskStatus)status;

        _unitOfWork.Save();

        return Ok();
    }
}