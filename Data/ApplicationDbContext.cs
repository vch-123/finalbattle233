using FinalBattle.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalBattle.Data
{
    //ApplicationDbContext负责处理数据库的上下文，可以说是封装Model对象，继承EFCore的DbContext
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


        //public DbSet<Race> Races { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Canvas> Canvases { get; set; }
        public DbSet<LikeMessage> LikeMessages { get; set; }
    }
}
