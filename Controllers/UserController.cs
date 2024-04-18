using FinalBattle.Interfaces;
using FinalBattle.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalBattle.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();

            var result = users.Select(user => new UserViewModel
            {
                Id = user.Id,               
                UserName = user.UserName,
                UserImageUrl = user.UserImageUrl
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                
                UserImageUrl = user.UserImageUrl,
                
            };

            return View(userDetailViewModel);

        }
    }
}
