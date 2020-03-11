using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class User
    {
        public User()
        {
            Interest = new HashSet<Interest>();
            Itinerary = new HashSet<Itinerary>();
            Place = new HashSet<Place>();
        }

        public int Userid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Interest> Interest { get; set; }
        public virtual ICollection<Itinerary> Itinerary { get; set; }
        public virtual ICollection<Place> Place { get; set; }
    }
}
