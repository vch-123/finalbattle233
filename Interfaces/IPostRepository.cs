using FinalBattle.Models;

namespace FinalBattle.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetByIdAsync(int id);
        Task<Post> GetByIdAsyncNoTracking(int id);
        //Task<IEnumerable<Post>> GetClubByCity(string city);
        bool Add(Post post);
        bool Update(Post post);
        bool Delete(Post post);
        bool Save();

    }
}
