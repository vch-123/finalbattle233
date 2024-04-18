using Microsoft.AspNetCore.Mvc;
using FinalBattle.Models;
using System.Threading.Tasks;
using FinalBattle.ViewModels;
using FinalBattle;
using FinalBattle.Interfaces;

public class CanvasController : Controller
{
    private readonly ICanvasRepository _canvasRepository;
    private readonly IPhotoService _photoService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CanvasController(ICanvasRepository canvasRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
    {
        _canvasRepository = canvasRepository;
        _photoService = photoService;
        _httpContextAccessor = httpContextAccessor;
    }

    // 显示画布列表
    public async Task<IActionResult> Index()
    {
        var canvases = await _canvasRepository.GetAllCanvasesAsync();
        return View(canvases);
    }

    // 显示添加画布的表单
    public IActionResult Create()
    {
        var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
        var createCanvasViewModel = new CreateCanvasViewModel { UserId = curUserId };
        return View(createCanvasViewModel);
        
    }

    // 处理添加画布的表单提交
    //这个注释看起来有点淡  但是没有到费眼睛的底部
    [HttpPost]
    public async Task<IActionResult> Create(CreateCanvasViewModel canvasVM)
    {
        if (ModelState.IsValid)
        {
            byte[] imageBytes = Convert.FromBase64String(canvasVM.Data);
            var canvas = new Canvas
            {
                Title = canvasVM.Title,

                Data = imageBytes,
                UserId = canvasVM.UserId,
                CreationTime = DateTime.Now,
            };
            _canvasRepository.CreateCanvasAsync(canvas);
            return RedirectToAction("Index");
        }
        else
        {
            ModelState.AddModelError("", "photo-upload-failed");
        }
        return View(canvasVM);
    }


}
