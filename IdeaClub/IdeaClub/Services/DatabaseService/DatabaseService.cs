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

        public UserProfile GetCurrentUserProfileWithFullInfo(ClaimsPrincipal user)
        {
            var userProfile = _db.UserProfile.Include(p => p.User).Include(p => p.Activities)
                .ThenInclude(c => c.Comments).ThenInclude(u => u.UserProfile).Include(p => p.Photos)
                .FirstOrDefault(p => p.User.Id == user.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userProfile;
        }

        public UserProfile GetUserProfileById(int id)
        {
            var userProfile = _db.UserProfile.Include(p => p.User).Include(p => p.Activities)
                .ThenInclude(c => c.Comments).ThenInclude(u => u.UserProfile).Include(p => p.Photos)
                .FirstOrDefault(u => u.Id == id);
            return userProfile;
        }

        public UserProfile GetCurrentUserProfile(ClaimsPrincipal user)
        {
            var userProfile = _db.UserProfile.Include(p => p.User)
                .FirstOrDefault(p => p.User.Id == user.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userProfile;
        }

        public Activities GetActivitiesById(int id)
        {
            var activity = _db.Activities.FirstOrDefault(p => p.Id == id);
            return activity;
        }

        public void AddPhoto(Photos photo)
        {
            _db.Photos.Add(photo);
            _db.SaveChanges();
        }

        public void AddActivities(Activities activity)
        {
            _db.Activities.Add(activity);
            _db.SaveChanges();
        }

        public void AddCommentToActivity(CommentsToActivities comment)
        {
            _db.CommentsToActivities.Add(comment);
            _db.SaveChanges();
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            _db.UserProfile.Update(userProfile);
            _db.SaveChanges();
        }
    }
}
