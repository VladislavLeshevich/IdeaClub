using System.Security.Claims;
using IdeaClub.Models.UsersInfoTables;

namespace IdeaClub.Services.DatabaseService
{
    interface IDatabaseService
    {
        UserProfile GetCurrentUserProfile(ClaimsPrincipal user);
        void AddPhoto(Photos photo);
        void UpdateUserProfile(UserProfile userProfile);
    }
}
