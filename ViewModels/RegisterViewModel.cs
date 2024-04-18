using System.ComponentModel.DataAnnotations;

namespace FinalBattle.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }
        [Display(Name = "密码")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        
        public string ConfirmPassword { get; set; }
    }
}
