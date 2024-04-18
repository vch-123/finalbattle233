using FinalBattle.Data.Enum;
using FinalBattle.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBattle.ViewModels
{
    public class CreateCanvasViewModel
    {
        

        public int Id { get; set; } // 唯一标识符       
        public string? Title { get; set; } // 画作的标题

        public DateTime? CreationTime { get; set; } // 创作时间

        public string? Data { get; set; } // 存储画作数据  base64
        
        [ForeignKey("User")]
        public string? UserId { get; set; }
      
    }
}
