using System;
using System.Collections.Generic;

namespace Toci.Call2Me.Database.Persistence.Models
{
    public partial class Incall
    {
        public int Id { get; set; }
        public int? Idusers { get; set; }
        public int? Iduserscall { get; set; }

        public virtual User? IdusersNavigation { get; set; }
        public virtual User? IduserscallNavigation { get; set; }
    }
}
