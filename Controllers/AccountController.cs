using Classroom.Mvc.Entities;
using Classroom.Mvc.Services;
using Classroom.Mvc.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Classroom.Mvc.Controllers;
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IUserManagementService _userManagement;

    public AccountController(
        ILogger<AccountController> logger,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IUserManagementService userManagement)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _userManagement = userManagement;
    }

    public ActionResult Index()
    {
        return RedirectToAction("/");
    }

    public ActionResult Register(string? returnUrl)
    {
        return View(new RegisterUserViewModel() { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<ActionResult> RegisterAsync(RegisterUserViewModel dtoModel)
    {
        if (!ModelState.IsValid)
            return View(dtoModel);

        //Manual mapping [Ustoz aytganligi uchun] har xil mapping usullaridan biri
        var model = new Models.AppUser()
        {
            UserName = dtoModel.UserName,
            FirstName = dtoModel.FirstName,
            LastName = dtoModel.LastName,
            Email = dtoModel.Email,
            UserImage = dtoModel.UserImage,
            Password = dtoModel.Password
        };

        var createUserResult = await _userManagement.CreateUserAsync(model);
        if(!createUserResult.IsSuccess)
        {
            ModelState.AddModelError(string.Empty, createUserResult.ErrorMessage ?? string.Empty);
            return View(dtoModel);
        }

        return Redirect($"/account/login?returnUrl={dtoModel.ReturnUrl}");
    }

    public ActionResult Login(string? returnUrl)
    {
        return View(new LoginUserViewModel() { ReturnUrl = returnUrl});
    }

    [HttpPost]
    public async Task<ActionResult> LoginAsync(LoginUserViewModel dtoModel)
    {
        if (!ModelState.IsValid) return View(dtoModel);
        var signInResult = await _signInManager.PasswordSignInAsync(dtoModel.UserName, dtoModel.Password, false, false);

        if (!signInResult.Succeeded) return View(dtoModel);

        return LocalRedirect($"{dtoModel.ReturnUrl ?? "/"}");
    }

    [HttpGet("[controller]/userImage")]
    public async Task<FileContentResult> GetUserImage(string? name)
    {
        var retrievedUserPhotoResult = await _userManagement.GetUserPhotoByUserNameAsync(name);
        if (!retrievedUserPhotoResult.IsSuccess) return new FileContentResult(System.IO.File.ReadAllBytes(Path.Combine(new string[5] { "wwwroot", "Media", "User", "Images", "avatar.png" })), "image/png");
        string contentType = string.Empty;
        new FileExtensionContentTypeProvider().TryGetContentType(retrievedUserPhotoResult.Data!, out contentType);

        string path = Path.Combine(new string[5] { "wwwroot", "Media", "User", "Images", retrievedUserPhotoResult.Data! });

        byte[] bytes = System.IO.File.ReadAllBytes(path);

        return new FileContentResult(bytes, contentType);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
    }
}
