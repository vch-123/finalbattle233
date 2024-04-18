using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using FinalBattle.Data.Enum;

namespace FinalBattle.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }    
        public string? Title { get; set; }   //标题
        public string? CoverImageUrl { get; set; }  //封面图
        public PostCategory? PostCategory { get; set; }  //帖子类别
        public string? Body { get; set; }  //帖子正文
        public DateTime? PublishDate { get; set; } //帖子发布日期

        [ForeignKey("LikeMessage")]
        public int? LikeMessageId { get; set; }
        public LikeMessage? LikeMessage { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

      
        


    }
}
