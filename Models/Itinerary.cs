using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class Itinerary
    {
        public Itinerary()
        {
            Itinerarydetails = new HashSet<Itinerarydetails>();
        }

        public int Itineraryid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int? Userid { get; set; }
        public int? Cityid { get; set; }

        public virtual City City { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Itinerarydetails> Itinerarydetails { get; set; }
    }
}
