using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class Itinerarydetails
    {
        public int Itinerarydetailid { get; set; }
        public int? Activityid { get; set; }
        public int? Itineraryid { get; set; }
        public string Activityname { get; set; }
        public int Priority { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Itinerary Itinerary { get; set; }
    }
}
