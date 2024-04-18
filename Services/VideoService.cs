using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using FinalBattle.Helpers;
using FinalBattle.Interfaces;
using Microsoft.Extensions.Options;

namespace FinalBattle.Services
{
    public class VideoService:IVideoService
    {
        private readonly Cloudinary _cloudinary;

        public VideoService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret);
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<VideoUploadResult> AddVideoAsync(IFormFile file)
        {
            var uploadResult = new VideoUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    // Specifying video transformation options
                    Transformation = new Transformation().Width(640).Height(360).Crop("limit").VideoCodec("auto")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeleteVideoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Video
            };
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }
    }
}
