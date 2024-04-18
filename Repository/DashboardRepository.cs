using FinalBattle.Data;
using FinalBattle.Interfaces;
using FinalBattle.Models;
using Microsoft.EntityFrameworkCore;


namespace FinalBattle.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Post>> GetAllUserPosts()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userPosts = _context.Posts.Where(r => r.User.Id == curUser.ToString());
            return userPosts.ToList();
        }

        

        public async Task<User> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
