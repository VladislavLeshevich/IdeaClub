using System.Security.Claims;
using IdeaClub.Models.UsersInfoTables;

namespace IdeaClub.Services.DatabaseService
{
    interface IDatabaseService
    {
        UserProfile GetCurrentUserProfile(ClaimsPrincipal user);
        UserProfile GetUserProfileById(int id);
        UserProfile GetCurrentUserProfileWithFullInfo(ClaimsPrincipal user);
        Activities GetActivitiesById(int id);
        void AddPhoto(Photos photo);
        void UpdateUserProfile(UserProfile userProfile);
        void AddActivities(Activities activity);
        void AddCommentToActivity(CommentsToActivities comment);
    }
}
