using FinalBattle.Interfaces;
using FinalBattle.Models;
using FinalBattle.Repository;
using FinalBattle.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalBattle.Controllers
{
    public class ResourceMallController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly ICourseRepository _courseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceMallController(ICourseRepository courseRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {

            _courseRepository = courseRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> lists = await _courseRepository.GetAll();
            return View(lists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createCourseViewModel = new CreateCourseViewModel();
            return View(createCourseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseViewModel courseVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(courseVM.CoverImageUrl);
                var course = new Course
                {
                    CourceName = courseVM.CourceName,
                    Description = courseVM.Description,
                    Price=courseVM.Price,  
                    CoverImageUrl = result.Url.ToString(),                              
                    PublishDate = DateTime.Now,
                    
                };
                _courseRepository.Add(course);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "photo-upload-failed");
            }
            return View(courseVM);
        }

        public async Task<IActionResult> Detail(int id)
        {

            Course course = await _courseRepository.GetByIdAsync(id);
            return View(course);
        }
    }
}
