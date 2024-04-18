using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBattle.Models
{
    public class Canvas
    {
        [Key]
        public int Id { get; set; } // 唯一标识符       
        public string? Title { get; set; } // 画作的标题
        
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreationTime { get; set; } // 创作时间

        public byte[]? Data { get; set; } // 存储画作数据


    }
}
