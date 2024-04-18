using FinalBattle.Models;

namespace FinalBattle.Interfaces
{
    public interface IDashboardRepository
    {

        Task<List<Post>> GetAllUserPosts();
        
        Task<User> GetUserById(string id);
        Task<User> GetByIdNoTracking(string id);
        bool Update(User user);
        bool Save();
    }
}
