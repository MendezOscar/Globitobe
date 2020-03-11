using System;
using System.Collections.Generic;

namespace globitobe.Models
{
    public partial class Category
    {
        public Category()
        {
            Activity = new HashSet<Activity>();
            Interest = new HashSet<Interest>();
        }

        public int Categoryid { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Activity> Activity { get; set; }
        public virtual ICollection<Interest> Interest { get; set; }
    }
}
