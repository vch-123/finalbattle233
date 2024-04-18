using FinalBattle.Data.Enum;

namespace FinalBattle.ViewModels
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime? PublishDate { get; set; }
        public IFormFile Image { get; set; }
        public PostCategory? PostCategory { get; set; }

        public String? URL { get; set; }

    }
}
