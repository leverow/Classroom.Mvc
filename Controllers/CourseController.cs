using Classroom.Mvc.Models;
using Classroom.Mvc.Services;
using Classroom.Mvc.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Classroom.Mvc.Controllers;

[Authorize]
public class CourseController : Controller
{
    private readonly ILogger<CourseController> _logger;
    private readonly ICourseService _courseService;
    private readonly UserManager<Entities.AppUser> _userManager;

    public CourseController(
        ILogger<CourseController> logger,
        ICourseService courseService,
        UserManager<Entities.AppUser> userManager)
    {
        _logger = logger;
        _courseService = courseService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "User not found");
            return View();
        };
        var userCourseList = user.UserCourses?.ToList();

        if (userCourseList is null)
            return View(new CourseMultipleViewModel() { UserCourse = new List<Entities.UserCourse>() });
        
        return View(new CourseMultipleViewModel() { UserCourse = userCourseList });
    }
    public IActionResult Create()
    {
        return View(new CreateCourseViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseViewModel dtoModel)
    {
        if(!ModelState.IsValid) return View(dtoModel);

        var createdCourseResult = await _courseService.CreateAsync(dtoModel.Adapt<Course>(), User.Identity?.Name);
        if(!createdCourseResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, createdCourseResult.ErrorMessage ?? string.Empty);
            return View(dtoModel);
        }

        return RedirectToAction("GetCourseById", new { id = createdCourseResult.Data!.Id });
    }

    [HttpGet("[controller]/id/{id}",Name = "get")]
    public async Task<IActionResult> GetCourseById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest("Invalid course Id");
        var retrievedCourseResult = await _courseService.GetCourseByIdAsync(Guid.Parse(id));
        if (!retrievedCourseResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, retrievedCourseResult.ErrorMessage ?? string.Empty);
            return View();
        }
        var user = await _userManager.GetUserAsync(User);

        var hasUserGotAccess = retrievedCourseResult.Data.UserCourses.Any(uc => uc.UserId == user.Id);
        
        if (!hasUserGotAccess)
            return View("NotFound", new CourseMultipleViewModel() { IsAccessDenied = true});
        
        return View(retrievedCourseResult.Data);
    }

    [HttpPost]
    public async Task<IActionResult> JoinCourse(string key)
    {
        if (string.IsNullOrWhiteSpace(key)) return BadRequest("Invalid key");

        var existingCourseResult = await _courseService.GetCourseByKeyAsync(key);
        if(!existingCourseResult.IsSuccess)
        {
            return View("NotFound", new CourseMultipleViewModel() { IsInValidKey = true});
        }
        var course = existingCourseResult.Data;

        var user = await _userManager.GetUserAsync(User);
        if (user is null) return BadRequest("User not found");

        if(!course.UserCourses.Any(u => u.UserId == user.Id))
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
    public async Task<FileContentResult> GetCourseBanner(uint type)
    {
        if (type >= 9 || type <= 0) type = 0;
        string contentType = string.Empty;
        new FileExtensionContentTypeProvider().TryGetContentType($"{type}.jpg", out contentType);

        string path = Path.Combine(new string[4] { "wwwroot", "Media", "Course", $"{type}.jpg" });

        byte[] bytes = System.IO.File.ReadAllBytes(path);

        return new FileContentResult(bytes, contentType);
    }
}
