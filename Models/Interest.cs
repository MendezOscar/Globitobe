using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class Interest
    {
        public int Interestid { get; set; }
        public int? Userid { get; set; }
        public int? Categoryid { get; set; }
        public string Categoryname { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
