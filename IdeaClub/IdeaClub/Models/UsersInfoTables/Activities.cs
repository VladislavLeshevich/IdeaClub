using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace IdeaClub.Models.UsersInfoTables
{
    public class Activities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public ICollection<CommentsToActivities> Comments { get; set; }
        public ICollection<LikesToActivities> Likes { get; set; }

    }
}
