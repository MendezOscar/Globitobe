using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class Place
    {
        public Place()
        {
            Activity = new HashSet<Activity>();
        }

        public int Placeid { get; set; }
        public string Name { get; set; }
        public string Imgurl { get; set; }
        public string Message { get; set; }
        public int? Userid { get; set; }
        public int? Cityid { get; set; }

        public virtual City City { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
