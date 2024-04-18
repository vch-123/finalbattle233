using System.ComponentModel.DataAnnotations;

namespace FinalBattle.Models
{
    public class LikeMessage
    {
        [Key]
        public int Id { get; set; }
        public int? LikeNumber { get; set; }
        public int? CommentNumber { get; set; }
        public string? ShareUrl { get; set; }
        
    }
}
