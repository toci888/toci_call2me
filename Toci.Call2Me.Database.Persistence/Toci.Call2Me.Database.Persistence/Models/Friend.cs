using System;
using System.Collections.Generic;

namespace Toci.Call2Me.Database.Persistence.Models
{
    public partial class Friend
    {
        public int Id { get; set; }
        public int? Idusers { get; set; }
        public int? Idusersfriend { get; set; }

        public virtual User? IdusersNavigation { get; set; }
        public virtual User? IdusersfriendNavigation { get; set; }
    }
}
