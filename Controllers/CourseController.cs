using Classroom.Mvc.Data;
using Classroom.Mvc.Models;
using Classroom.Mvc.Repository;
using Classroom.Mvc.Services;
using Classroom.Mvc.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Classroom.Mvc.Controllers;

[Authorize]
public partial class CourseController : Controller
{
    private readonly ILogger<CourseController> _logger;
    private readonly ICourseService _courseService;
    private readonly UserManager<Entities.AppUser> _userManager;
    private readonly IAppTaskService _taskService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _context;

    public CourseController(
        ILogger<CourseController> logger,
        ICourseService courseService,
        UserManager<Entities.AppUser> userManager,
        IAppTaskService appTaskService,
        IUnitOfWork unitOfWork,
        AppDbContext context)
    {
        _logger = logger;
        _courseService = courseService;
        _userManager = userManager;
        _taskService = appTaskService;
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public IActionResult Create()
        => View(new CreateCourseViewModel());

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseViewModel dtoModel)
    {
        if (!ModelState.IsValid) return View(dtoModel);

        var createdCourseResult = await _courseService.CreateAsync(dtoModel.Adapt<Course>(), User.Identity?.Name);
        if (!createdCourseResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, createdCourseResult.ErrorMessage ?? string.Empty);
            return View(dtoModel);
        }

        return RedirectToAction("GetCourseById", new { id = createdCourseResult.Data!.Id });
    }

    [HttpGet("[controller]/id/{id}")]
    public async Task<IActionResult> GetCourseById(Guid id)
    {
        var retrievedCourseResult = await _courseService.GetCourseByIdAsync(id);
        if (!retrievedCourseResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, retrievedCourseResult.ErrorMessage ?? string.Empty);
            return View();
        }
        var user = await _userManager.GetUserAsync(User);

        var course = retrievedCourseResult.Data!;

        if (course.UserCourses?.Any(uc => uc.UserId == user.Id) != true)
            return View("NotFound", new CourseMultipleViewModel() { IsAccessDenied = true });

        return View(course);
    }

    [HttpPost("[controller]/join")]
    public async Task<IActionResult> JoinCourse(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return BadRequest("Invalid key");

        var existingCourseResult = await _courseService.GetCourseByKeyAsync(key);
        if(!existingCourseResult.IsSuccess)
            return View("NotFound", new CourseMultipleViewModel() { IsInValidKey = true});
        
        var course = existingCourseResult.Data;

        var user = await _userManager.GetUserAsync(User);
        if (user is null)
            return BadRequest("User not found");

        if(course!.UserCourses?.Any(u => u.UserId == user.Id) != true)
        {
            course.UserCourses?.Add(new Entities.UserCourse()
            {
                UserId = user.Id,
                CourseId = course.Id
            });
            _courseService.Save();
        }

        return RedirectToAction("GetCourseById", new { id = course.Id });
    }

    [HttpGet("[controller]/banner")]
    public FileContentResult GetCourseBanner(uint type)
    {
        if (type >= 9 || type <= 0) type = 0;
        string contentType = string.Empty;
        new FileExtensionContentTypeProvider().TryGetContentType($"{type}.jpg", out contentType);

        string path = Path.Combine(new string[4] { "wwwroot", "Media", "Course", $"{type}.jpg" });

        byte[] bytes = System.IO.File.ReadAllBytes(path);

        return new FileContentResult(bytes, contentType);
    }
}
