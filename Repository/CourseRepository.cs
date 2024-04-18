using FinalBattle.Data;
using FinalBattle.Interfaces;
using FinalBattle.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalBattle.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Course course)
        {
            _context.Add(course);
            return Save();
        }
        public bool Update(Course course)
        {
            _context.Update(course);
            return Save();
        }

        public bool Delete(Course course)
        {
            _context.Remove(course);
            return Save();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(i => i.Id == id);
        }
        //111
        public async Task<Course> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
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
