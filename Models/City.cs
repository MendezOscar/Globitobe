using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class City
    {
        public City()
        {
            Itinerary = new HashSet<Itinerary>();
            Place = new HashSet<Place>();
        }

        public int Cityid { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Imgurl { get; set; }

        public virtual ICollection<Itinerary> Itinerary { get; set; }
        public virtual ICollection<Place> Place { get; set; }
    }
}
