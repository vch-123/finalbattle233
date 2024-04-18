using FinalBattle.Models;

namespace FinalBattle.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetByIdAsync(int id);
        Task<Course> GetByIdAsyncNoTracking(int id);
        
        bool Add(Course course);
        bool Update(Course course);
        bool Delete(Course course);
        bool Save();
    }
}
