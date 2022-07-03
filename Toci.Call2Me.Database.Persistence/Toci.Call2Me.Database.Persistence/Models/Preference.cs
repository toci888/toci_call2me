using System;
using System.Collections.Generic;

namespace Toci.Call2Me.Database.Persistence.Models
{
    public partial class Preference
    {
        public int Id { get; set; }
        public int? Allowflag { get; set; }
        public int? Idusers { get; set; }

        public virtual User? IdusersNavigation { get; set; }
    }
}
