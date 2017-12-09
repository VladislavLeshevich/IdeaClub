using System.Linq;
using System.Security.Claims;
using IdeaClub.Data;
using IdeaClub.Models.UsersInfoTables;
using Microsoft.EntityFrameworkCore;

namespace IdeaClub.Services.DatabaseService
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ApplicationDbContext _db;

        public DatabaseService(ApplicationDbContext db)
        {
            _db = db;
        }

        public UserProfile GetCurrentUserProfile(ClaimsPrincipal User)
        {
            var userProfile = _db.UserProfile.Include(p => p.User).Include(p => p.Photos)
                .FirstOrDefault(p => p.User.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userProfile;
        }

        public void AddPhoto(Photos photo)
        {
            _db.Photos.Add(photo);
            _db.SaveChanges();
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            _db.UserProfile.Update(userProfile);
            _db.SaveChanges();
        }
    }
}
