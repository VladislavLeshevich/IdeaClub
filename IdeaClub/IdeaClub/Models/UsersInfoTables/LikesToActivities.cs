using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdeaClub.Models.UsersInfoTables
{
    public class LikesToActivities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Activities Activities { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
