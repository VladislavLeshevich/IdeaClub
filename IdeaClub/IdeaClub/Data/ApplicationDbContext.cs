using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdeaClub.Models.UsersInfoTables;

namespace IdeaClub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public static DbContextOptions<ApplicationDbContext> Options;
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<CommentsToActivities> CommentsToActivities { get; set; }
        public DbSet<LikesToActivities> LikesToActivities { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<Photos> Photos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Options = options;
        }

       
    }
}
