using CloudinaryDotNet.Actions;
using FinalBattle.Data.Enum;
using Microsoft.AspNetCore.Http; // 确保有这个引用来使用 IFormFile

namespace FinalBattle.ViewModels
{
    public class CreateCourseViewModel
    {
        public int Id { get; set; }
        public string? CourceName { get; set; }   //资源名
        public IFormFile? CoverImageUrl { get; set; }  //课程封面图
        public string? Description { get; set; } //课程简述

        public string? Price { get; set; } //课程价格
        public DateTime? PublishDate { get; set; } //课程发布日期
        //public List<IFormFile>? Videos { get; set; } // 添加这行来支持视频上传

    }
}
