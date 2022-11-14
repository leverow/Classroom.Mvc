using Classroom.Mvc.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Classroom.Mvc.Services;

public class UserManagementService : IUserManagementService
{
    private readonly ILogger<UserManagementService> _logger;
    private readonly UserManager<Entities.AppUser> _userManager;

    public UserManagementService(
        ILogger<UserManagementService> logger,
        UserManager<Entities.AppUser> userManager
    )
    {
        _logger = logger;
        _userManager = userManager;
    }
    public async Task<Result> CreateUserAsync(AppUser model)
    {
        var validationResult = Validate(model);
        if (!validationResult.IsSuccess) return new("One or more fields are invalid.");

        var savedUserImageResult = await SaveUserImageAsync(model.UserImage);
        
        var user = model.Adapt<Entities.AppUser>();

        var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
        if (existingUser != null) return new("User with given username already exist.");

        user.PhotoUrl = savedUserImageResult.Data;

        try
        {
            var createUserResult = await _userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
            {
                var errors = string.Join('\n', createUserResult.Errors.Select(e => e.Code));
                return new(errors);
            }
            return new(true);
        }
        catch (DbUpdateException dbUpdateException)
        {
            _logger.LogInformation("Error occured:", dbUpdateException);
            return new("Couldn't create the user. Contact support.");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserManagementService)}", e);
            throw new("Couldn't create the user. Contact support.", e);
        }
    }

    public async Task<Result> DeleteUserByIdAsync(Guid id)
    {
        if (id == default) return new("User id is invalid");
        try
        {
            var existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser is null) return new("The user with given ID not found.");

            var deletedUser = await _userManager.DeleteAsync(existingUser);
            if (!deletedUser.Succeeded) return new("Removing the user failed. Contact support");

            return new(true);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserManagementService)}", e);
            throw new("Couldn't delete the user. Contact support", e);
        }
    }

    public async Task<Result<AppUser>> GetUserByIdAsync(Guid id)
    {
        if (id == default) return new("User id is invalid");
        try
        {
            var existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser is null) return new("The user with given ID not found");

            return new(true) { Data = ToModel(existingUser) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserManagementService)}", e);
            throw new("Couldn't retrieve the user. Contact support", e);
        }
    }

    public async Task<Result<AppUser>> GetUserByUserNameAsync(string? userName)
    {
        if (string.IsNullOrWhiteSpace(userName)) return new("Username is invalid.");
        try
        {
            var existingUser = await _userManager.FindByNameAsync(userName);
            if (existingUser is null) return new("The user with given username not found");

            return new(true) { Data = ToModel(existingUser) };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserManagementService)}", e);
            throw new("Couldn't retrieve the user. Contact support", e);
        }
    }

    public async Task<Result<string>> GetUserPhotoByUserNameAsync(string? userName)
    {
        if (string.IsNullOrWhiteSpace(userName)) return new("Username is invalid.");
        try
        {
            var existingUser = await _userManager.FindByNameAsync(userName);
            if (existingUser is null) return new("The user with given username not found");

            return new(true) { Data = existingUser.PhotoUrl ?? "avatar.png" };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserManagementService)}", e);
            throw new("Couldn't retrieve profile image. Contact support", e);
        }
    }

    public async Task<Result> UpdateUserAsync(Guid id, AppUser model)
    {
        if (id == default) return new("User id is invalid");

        var validationResult = Validate(model);
        if (!validationResult.IsSuccess) return new("One or more fields are invalid.");

        var savedUserImageResult = await SaveUserImageAsync(model.UserImage);

        var existingUser = await _userManager.FindByIdAsync(id.ToString());
        existingUser.FirstName = model.FirstName;
        existingUser.UserName = model.UserName;
        existingUser.Email = model.Email;
        existingUser.PhotoUrl = savedUserImageResult.Data;

        try
        {
            var updateUserResult = await _userManager.UpdateAsync(existingUser);
            if (!updateUserResult.Succeeded) return new("Couldn't update the user. Contact support");

            return new(true);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error occured at {nameof(UserManagementService)}", e);
            throw new("Couldn't update the user. Contact support", e);
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    => await _userManager.Users.AnyAsync(u => u.Id == id);

    private Result Validate(AppUser model)
    {
        if (model.UserImage is null)
            return new("Invalid User image.");
        if (string.IsNullOrWhiteSpace(model.FirstName))
            return new("Invalid firstname.");

        if (string.IsNullOrWhiteSpace(model.LastName))
            return new("Invalid lastname.");

        if (string.IsNullOrWhiteSpace(model.UserName))
            return new("Invalid username.");

        if (!string.IsNullOrWhiteSpace(model.Email) && !new EmailAddressAttribute().IsValid(model.Email))
            return new("Invalid email.");

        var supportedTypes = new[] { "jpg", "png" };
        var fileExt = System.IO.Path.GetExtension(model.UserImage.FileName).Substring(1);
        if (!supportedTypes.Contains(fileExt))
            return new("Image extension is invalid - Only Upload Jpg/Png File");

        return new(true);
    }

    //Manual mapper [Ustoz aytganligi uchun atayin yozildi]
    private AppUser ToModel(Entities.AppUser entity)
    => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        UserName = entity.UserName,
        Email = entity.Email,
        UserImageUrl = entity.PhotoUrl
    };

    private async Task<Result<string>> SaveUserImageAsync(IFormFile? userImageFile)
    {
        if (userImageFile is null) return new(false) { Data = "avatar.png" };

        var imagePath = Guid.NewGuid().ToString("N") + Path.GetExtension(userImageFile.FileName);
        CreateDirectoryWhenNotExist();

        var ms = new MemoryStream();
        await userImageFile.CopyToAsync(ms);
        System.IO.File.WriteAllBytes(Path.Combine(new string[5] { "wwwroot", "Media", "User", "Images", imagePath }), ms.ToArray());

        return new(true) { Data = imagePath };
    }
    private void CreateDirectoryWhenNotExist()
    {
        var path = Path.Combine(new string[4] { "wwwroot", "Media", "User", "Images"});
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    private async Task<Result<string>> SaveUserImageAsync(string? imageUrl)
    {
        if (imageUrl is null) return new(false) { Data = "avatar.png" };
        var isSucceed = false;
        var imageName = Guid.NewGuid().ToString("N") + ".jpg";
        CreateDirectoryWhenNotExist();

        using (HttpClient webClient = new HttpClient())
        {
            byte[] data = await webClient.GetByteArrayAsync(imageUrl);

            using (MemoryStream mem = new MemoryStream(data))
            {
                await System.IO.File.WriteAllBytesAsync(Path.Combine(new string[5] { "wwwroot", "Media", "User", "Images", imageName }), mem.ToArray());
                isSucceed = true;
            }
        }
        if (isSucceed)
            return new(true) { Data = imageName };
        else
            return new(false) { Data = "avatar.png" };
    }
}