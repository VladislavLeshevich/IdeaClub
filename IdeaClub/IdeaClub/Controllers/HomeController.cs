using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdeaClub.Models;
using Microsoft.AspNetCore.Authorization;
using IdeaClub.Data;
using IdeaClub.Models.UsersInfoTables;
using Microsoft.AspNetCore.Http;
using IdeaClub.Services.DatabaseService;
using IdeaClub.Services.ImageService;

namespace IdeaClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IDatabaseService _databaseService;

        public HomeController(ApplicationDbContext db)
        {
            _imageService = new ImageService();
            _databaseService = new DatabaseService(db);
        }

        [Authorize]
        public IActionResult Index()
        {
            var userProfile = _databaseService.GetCurrentUserProfile(User);
            return View(userProfile);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public async Task<RedirectToActionResult> AddNewPhoto(IFormFile photo)
        {
            var imageUrl = await _imageService.UploadImageToCloudinaryAsync(photo);
            var userProfile = _databaseService.GetCurrentUserProfile(User);
            var image = new Photos
            {
                UrlPhotos =  imageUrl,
                UserProfile = userProfile
            };
           _databaseService.AddPhoto(image);
            return RedirectToAction("Index");
        }

        [HttpPost("UploadFiles")]
        public async Task<RedirectToActionResult> ChangeMainPhoto(IFormFile photo)
        {
            var imageUrl = await _imageService.UploadImageToCloudinaryAsync(photo);
            var userProfile = _databaseService.GetCurrentUserProfile(User);
            userProfile.UrlPhoto = imageUrl;
            _databaseService.UpdateUserProfile(userProfile);
            return RedirectToAction("Index");
        }

        public ActionResult Photos()
        {
            return PartialView("_Photos");
        }

    }
}
