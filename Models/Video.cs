using CloudinaryDotNet;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBattle.Models
{
    public class Video
    {
        public int VideoId { get; set; } // 视频的唯一标识符
        public string? Title { get; set; } // 视频标题
        public int? Duration { get; set; } // 视频时长，单位为秒
        public string? Url { get; set; } // 视频的URL地址


        [ForeignKey("Course")]
        // 外键属性，表示属于哪个课程
        public int? CourseId { get; set; }
        // 导航属性，用于EF Core建立关系
        public Course? Course { get; set; }
    }
}
