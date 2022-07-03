using System;
using System.Collections.Generic;

namespace Toci.Call2Me.Database.Persistence.Models
{
    public partial class User
    {
        public User()
        {
            FriendIdusersNavigations = new HashSet<Friend>();
            FriendIdusersfriendNavigations = new HashSet<Friend>();
            IncallIdusersNavigations = new HashSet<Incall>();
            IncallIduserscallNavigations = new HashSet<Incall>();
            Preferences = new HashSet<Preference>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phonenumber { get; set; }
        public int? Idstatus { get; set; }

        public virtual Status? IdstatusNavigation { get; set; }
        public virtual ICollection<Friend> FriendIdusersNavigations { get; set; }
        public virtual ICollection<Friend> FriendIdusersfriendNavigations { get; set; }
        public virtual ICollection<Incall> IncallIdusersNavigations { get; set; }
        public virtual ICollection<Incall> IncallIduserscallNavigations { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
