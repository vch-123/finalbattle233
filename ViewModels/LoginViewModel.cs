using System.ComponentModel.DataAnnotations;

namespace FinalBattle.ViewModels
{
    public class LoginViewModel
    {
        
            [Display(Name = "邮箱")]
            [Required(ErrorMessage = "邮箱不可为空")]
            public string EmailAddress { get; set; }
            [Display(Name = "密码")]
        
            [DataType(DataType.Password)]
            public string Password { get; set; }
        

    }
}
