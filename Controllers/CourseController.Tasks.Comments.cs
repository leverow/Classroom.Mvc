using Classroom.Mvc.Models;
using Classroom.Mvc.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Mvc.Controllers;
public partial class CourseController
{
    [HttpPost("[controller]/id/{courseId}/tasks/{taskId}/comments")]
    public async Task<IActionResult> AddTaskComments(Guid courseId, Guid taskId, CreateTaskCommentViewModel taskCommentDto)
    {
        var existingTask = await _taskService.GetTaskByIdAsync(courseId, taskId);
        if (existingTask.Data is null)
            return Ok();

        var user = await _userManager.GetUserAsync(User);

        existingTask.Data.Comments ??= new List<Entities.TaskComment>();

        existingTask.Data.Comments.Add(new Entities.TaskComment()
        {
            TaskId = taskId,
            UserId = user.Id,
            Message = taskCommentDto.Message,
            ParentId = taskCommentDto.ParentId,
            CreatedDate = DateTime.UtcNow.AddHours(5)
        });

        await _context.SaveChangesAsync();

        return RedirectToAction("GetTaskById","Course", new { courseId = courseId, taskId = taskId});
    }
}