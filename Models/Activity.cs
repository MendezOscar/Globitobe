using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Itinerarydetails = new HashSet<Itinerarydetails>();
        }

        public int Activityid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public int? Duration { get; set; }
        public string Imgurl { get; set; }
        public string Message { get; set; }
        public int? Placeid { get; set; }
        public int? Categoryid { get; set; }
        public string Placename { get; set; }
        public string Categoryname { get; set; }

        public virtual Category Category { get; set; }
        public virtual Place Place { get; set; }
        public virtual ICollection<Itinerarydetails> Itinerarydetails { get; set; }
    }
}
