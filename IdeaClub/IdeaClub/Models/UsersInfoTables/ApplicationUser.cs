using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IdeaClub.Models.UsersInfoTables
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UrlPhoto { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FacebookLink { get; set; }
        public string VkontakteLink { get; set; }
        public string TwitterLink { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Activities> Activities { get; set; } 
        public ICollection<Photos> Photos { get; set; }
        public ICollection<PersonalInformation> PersonalInformation { get; set; }
    }

}
