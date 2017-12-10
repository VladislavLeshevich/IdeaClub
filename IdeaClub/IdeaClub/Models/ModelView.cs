using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdeaClub.Models.UsersInfoTables;

namespace IdeaClub.Models
{
    public class ModelView
    {
        public UserProfile UserProfile { get; set; }
        public UserProfile CurrentUserProfile { get; set; }
    }
}
