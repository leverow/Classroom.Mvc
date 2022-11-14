using System.ComponentModel.DataAnnotations;

namespace Classroom.Mvc.ViewModels;

public class RegisterUserViewModel
{
    [Required(ErrorMessage = "Ismingizni kiritishingiz lozim!")]
    [MinLength(6, ErrorMessage = "Ismingizda kamida 6ta belgi qatnashishi kerak.")]
    [MaxLength(21, ErrorMessage = "Ismingiz 21ta belgidan oshmasligi lozim.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Familyangizni kiritishingiz lozim!")]
    [MinLength(6, ErrorMessage = "Familyangizda kamida 6ta belgi qatnashishi kerak.")]
    [MaxLength(21, ErrorMessage = "Familyangiz 21ta belgidan oshmasligi lozim.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Login tanlashingiz lozim!")]
    [MinLength(6,ErrorMessage = "Loginda kamida 6ta belgi qatnashishi kerak.")]
    [MaxLength(21,ErrorMessage = "Login 21ta belgidan oshmasligi lozim.")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Email kiritishingiz lozim!")]
    [DataType(DataType.EmailAddress,ErrorMessage = "Email manzili noto'g'ri kiritildi.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Parol kiritishingiz lozim!")]
    [DataType(DataType.Password,ErrorMessage = "Parol noto'g'ri kiritildi.")]
    [MinLength(6,ErrorMessage = "Parol kamida 6ta belgidan iborat bo'lishi kerak.")]
    [MaxLength(21,ErrorMessage = "Parol 21ta belgidan oshmasligi zarur.")]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Parol va tasdiqlash parollari bir xil bo'lishi lozim!")]
    public string ConfirmPassword { get; set; }

    [Required]
    public IFormFile? UserImage { get; set; }

    public string? ReturnUrl { get; set; }
}