using FinalBattle.Data;
using FinalBattle.Interfaces;
using FinalBattle.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalBattle.Repository
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Post post)
        {
            _context.Add(post);
            return Save();
        }
        public bool Update(Post post)
        {
            _context.Update(post);
            return Save();
        }

        public bool Delete(Post post)
        {
            _context.Remove(post);
            return Save();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(i => i.Id == id);
        }
        //111
        public async Task<Post> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Posts.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        //public async Task<IEnumerable<Post>> GetClubByCity(string city)
        //{
        //    return await _context.Posts.Where(c => c.Address.City.Contains(city)).ToListAsync();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        
    }
}
