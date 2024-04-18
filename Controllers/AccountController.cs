using FinalBattle.Data;
using FinalBattle.Interfaces;
using FinalBattle.Migrations;
using FinalBattle.Models;
using FinalBattle.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalBattle.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager; //identity
        private readonly ApplicationDbContext _dbContext;
        //private readonly IPhotoService _photoService; //创建用户的时候没必要放头像- -
        private readonly IHttpContextAccessor _httpContextAccessor;


        //        UserManager<TUser> 和 SignInManager<TUser> 是 ASP.NET Core Identity 提供的两个重要的服务类，用于处理用户的身份验证和授权。

        //UserManager<TUser>：

        //UserManager<TUser> 是 ASP.NET Core Identity 提供的用户管理类。它提供了一组用于管理用户的方法，包括创建用户、查找用户、验证用户凭据、管理用户角色和声明等。它还提供了密码哈希、令牌生成和验证等安全功能。
        //TUser 是您的应用程序中定义的用户实体类。通过泛型类型参数 TUser，您可以指定用于表示用户的自定义类。
        //SignInManager<TUser>：

        //SignInManager<TUser> 是 ASP.NET Core Identity 提供的用户登录管理类。它处理用户的身份验证、登录和注销操作。
        //它提供了一组用于处理用户登录状态的方法，包括验证用户凭据、登录用户、注销用户等。它还提供了处理 Cookie 认证的功能，使得用户在登录后可以持续保持登录状态。


        public AccountController(UserManager<User> userManager, SignInManager<User> signManager, ApplicationDbContext dbContext,IPhotoService photoService,IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signManager;
            _dbContext = dbContext;
            //_photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);//这个动作方法的作用是在用户访问登录页面时，创建一个空的 LoginViewModel 对象，并将其传递给登录视图。这样，登录视图就可以使用该对象来显示登录表单、接收用户输入的登录凭据等。
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if (user != null)
            {
                //User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    //Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        //string imageUrl = // 获取用户头像URL的逻辑

                        //_httpContextAccessor.HttpContext.Session.SetString("UserImageUrl", user.UserImageUrl);


                        return RedirectToAction("Index", "Post");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginVM);
            }
            //User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginVM);
        }
        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            var newUser = new User()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction("Index", "Race");
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Post");
        }

    }
}
