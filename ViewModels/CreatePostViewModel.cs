using FinalBattle.Data.Enum;
using FinalBattle.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace FinalBattle.ViewModels
{
    public class CreatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime? PublishDate { get; set; }
        public IFormFile CoverImageUrl { get; set; }
        public PostCategory PostCategory { get; set; }

        public string UserId { get; set; }

}
}
