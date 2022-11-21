using Classroom.Mvc.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Mvc.Controllers;
public partial class CourseController
{
    [HttpGet("[controller]/id/{courseId}/tasks/create")]
    public IActionResult CreateTask(Guid courseId)
    {
        return View(new CreateTaskViewModel() { CourseId = courseId});
    }

    [HttpPost("[controller]/id/{courseId}/tasks/create")]
    public async Task<IActionResult> CreateTask(CreateTaskViewModel dtoModel)
    {
        if (!ModelState.IsValid)
            return View(dtoModel);

        var model = dtoModel.Adapt<Models.AppTask>();

        var createdTaskResult = await _taskService.CreateAsync(model, User);
        if (!createdTaskResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, createdTaskResult.ErrorMessage ?? string.Empty);
            return View(dtoModel);
        }

        return RedirectToAction("GetCourseById", "Course", new { id = dtoModel.CourseId });
    }

    [HttpGet("[controller]/id/{courseId}/tasks/{taskId}")]
    public async Task<IActionResult> GetTaskById(Guid courseId, Guid taskId)
    {
        //TODO userni kurs azosi ekanligini tekshiramiz
        var retrievedTaskResult = await _taskService.GetTaskByIdAsync(courseId, taskId);
        if (!retrievedTaskResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, retrievedTaskResult.ErrorMessage ?? string.Empty);
            return View();
        }
        return View(retrievedTaskResult.Data);
    }

    [HttpGet("[controller]/id/{courseId}/tasks/{taskId}/edit")]
    public IActionResult UpdateTask(Guid courseId, Guid taskId)
    {
        if(courseId == default || taskId == default)
        {
            ModelState.AddModelError(string.Empty, "Kurs idsi yoki vazifa idsi noto'g'ri kiritildi!");
            return View();
        }
        return View(new UpdateTaskViewModel() { CourseId = courseId, TaskId = taskId});
    }
    [HttpPost("[controller]/id/{courseId}/tasks/{taskId}/edit")]
    public async Task<IActionResult> UpdateTask(UpdateTaskViewModel dtoModel)
    {
        if (!ModelState.IsValid)
            return View(dtoModel);

        var model = dtoModel.Adapt<Models.AppTask>();

        var updatedTaskResult = await _taskService.UpdateAsync(model);
        if(!updatedTaskResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, updatedTaskResult.ErrorMessage ?? string.Empty);
            return View(dtoModel);
        }

        return RedirectToAction("GetCourseById", "Course", new { id = dtoModel.CourseId });
    }

    [HttpGet("[controller]/id/{courseId}/tasks/{taskId}/delete")]
    public async Task<IActionResult> DeleteTask(Guid courseId, Guid taskId)
    {
        var deletedTaskResult = await _taskService.RemoveByIdAsync(courseId, taskId);

        if(!deletedTaskResult.IsSuccess)
            return RedirectToAction("GetCourseById", "Course", new { id = courseId });

        return RedirectToAction("GetCourseById", "Course", new { id = courseId });
    }
}