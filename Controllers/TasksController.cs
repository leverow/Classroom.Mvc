using Classroom.Mvc.Repository;
using Classroom.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Mvc.Controllers;
public class TasksController : Controller
{
    private readonly ILogger<TasksController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public TasksController(
        ILogger<TasksController> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskViewModel dtoModel)
    {
        if (!ModelState.IsValid) return Ok(dtoModel);

        
        return Ok(dtoModel);
    }
}