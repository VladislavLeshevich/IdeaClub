using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace IdeaClub.Services.ImageService
{
    public class ImageService : IImageService 
    {
        public async Task<string> UploadImageToCloudinaryAsync(IFormFile image)
        {
            var account = new Account(
                "dr4opxk5i",
                "914384991613964",
                "kSIgSsK5FNVly0E6nNzFLV2dUjY");

            var cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.FileName, image.OpenReadStream())
            };
            var result = await cloudinary.UploadAsync(uploadParams);
            return result.Uri.AbsoluteUri;
        }
    }
}
