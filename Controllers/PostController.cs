using FinalBattle.Interfaces;
using FinalBattle.Models;
using FinalBattle.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace FinalBattle.Controllers
{
    public class PostController : Controller
    {

        //这里需要用到爱情
        private readonly IPhotoService _photoService;
        private readonly IPostRepository _postRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostController(IPostRepository postRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {

            _postRepository = postRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Post> lists = await _postRepository.GetAll();
            return View(lists);
        }

        public async Task<IActionResult> Detail(int id)
        {

            Post post = await _postRepository.GetByIdAsync(id);
            return View(post);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createPostViewModel = new CreatePostViewModel { UserId = curUserId };
            return View(createPostViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(postVM.CoverImageUrl);
                var post = new Post
                {
                    Title = postVM.Title,
                    Body = postVM.Body,
                    CoverImageUrl = result.Url.ToString(),
                    PostCategory = postVM.PostCategory,
                    UserId = postVM.UserId,
                    PublishDate=DateTime.Now,
                    //Address = new Address
                    //{
                    //    Street = clubVM.Address.Street,
                    //    City = clubVM.Address.City,
                    //    State = clubVM.Address.State,
                    //}
                };
                _postRepository.Add(post);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "photo-upload-failed");
            }
            return View(postVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null) return View("Error");
            var postVM = new EditPostViewModel
            {
                Title = post.Title,
                Body = post.Body,
                URL = post.CoverImageUrl,
                PostCategory = post.PostCategory,
                PublishDate = DateTime.Now,
            };
            return View(postVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPostViewModel postVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post");
                return View("Edit", postVM);
            }
            var userPost = await _postRepository.GetByIdAsyncNoTracking(id);

            if (userPost != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userPost.CoverImageUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "can not delete photo");
                    return View(postVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(postVM.Image);

                var post = new Post
                {
                    Id = id,
                    Title = postVM.Title,
                    Body = postVM.Body,
                    CoverImageUrl = photoResult.Url.ToString(),
                    PostCategory = postVM.PostCategory,
                PublishDate = DateTime.Now,
                };

                _postRepository.Update(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View(postVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var clubDetails = await _postRepository.GetByIdAsync(id);
            if (clubDetails == null) return View("Error");
            return View(clubDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postDetails = await _postRepository.GetByIdAsync(id);
            if (postDetails == null) return View("Error");

            _postRepository.Delete(postDetails);
            return RedirectToAction("Index");
        }




    }
}
