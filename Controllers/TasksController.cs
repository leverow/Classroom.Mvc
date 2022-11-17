using Classroom.Mvc.Repository;
using Classroom.Mvc.Services;
using Classroom.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Mvc.Controllers;
public class TasksController : Controller
{
    private readonly ILogger<TasksController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppTaskService _taskService;

    public TasksController(
        ILogger<TasksController> logger,
        IUnitOfWork unitOfWork,
        IAppTaskService appTaskService)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _taskService = appTaskService;
    }

    [HttpGet("[controller]/create/courseId/{targetCourseId}")]
    public IActionResult Create(string? targetCourseId)
    {
        if (string.IsNullOrWhiteSpace(targetCourseId)) return BadRequest("Target Course Id is invalid.");

        return View(new CreateTaskViewModel() { TargetCourseId = Guid.Parse(targetCourseId)});
    }

    [HttpPost("[controller]/create/courseId/{targetCourseId}")]
    public async Task<IActionResult> Create(CreateTaskViewModel dtoModel)
    {
        if (!ModelState.IsValid) return Ok(dtoModel);

        var model = new Models.AppTask()
        {
            Description = dtoModel.Description,
            Title = dtoModel.Title!,
            Url = dtoModel.Url,
            MaxScore = dtoModel.MaxScore,
            StartDate = dtoModel.StartDate,
            EndDate = dtoModel.EndDate,
            CourseId = dtoModel.TargetCourseId
        };

        var createdTaskResult = await _taskService.CreateAsync(model);
        if (!createdTaskResult.IsSuccess)
            return BadRequest($"Task create bo`lmadi. Sabab: {createdTaskResult.ErrorMessage}");

        return RedirectToAction("GetCourseById", "Course", new { id = dtoModel.TargetCourseId });
    }
}