using CloudinaryDotNet.Actions;

namespace FinalBattle.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourceName { get; set; }   //资源名
        public string? CoverImageUrl { get; set; }  //课程封面图
        public string? Description { get; set; } //课程简述

        public string? Price {  get; set; } //课程价格
        public DateTime? PublishDate { get; set; } //课程发布日期
        public ICollection<Video> Videos { get; set; }
    }
}
