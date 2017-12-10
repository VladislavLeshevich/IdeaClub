using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace IdeaClub.Models.UsersInfoTables
{
    public class CommentsToActivities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }

        public UserProfile UserProfile { get; set; }
        public Activities Activities { get; set; }
    }
}
