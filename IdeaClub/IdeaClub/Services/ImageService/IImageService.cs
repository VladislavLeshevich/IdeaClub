using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IdeaClub.Services.ImageService
{
    interface IImageService
    {
        Task<string> UploadImageToCloudinaryAsync(IFormFile image);
    }
}
