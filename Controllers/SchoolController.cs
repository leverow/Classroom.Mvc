using Classroom.Mvc.Models;
using Classroom.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Classroom.Mvc.Controllers;
public class SchoolController : Controller
{
    private readonly ILogger<SchoolController> _logger;
    private readonly ISchoolService _schoolService;

    public SchoolController(
        ILogger<SchoolController> logger,
        ISchoolService schoolService)
    {
        _logger = logger;
        _schoolService = schoolService;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var schools = (await _schoolService.GetAllSchoolsAsync()).Data;
        if (schools.Count() == 0) return View(new List<School>()
        { 
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Not found",
                Description = "Not found"
            }
        });

        return View(schools.ToList());
    }
}
