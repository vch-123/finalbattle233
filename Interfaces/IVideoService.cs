using CloudinaryDotNet.Actions;

namespace FinalBattle.Interfaces
{
    public interface IVideoService
    {
        Task<VideoUploadResult> AddVideoAsync(IFormFile file);
        Task<DeletionResult> DeleteVideoAsync(string publicId);
    }
}
