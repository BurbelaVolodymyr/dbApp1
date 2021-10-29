using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Country
    {
        public Country()
        {
            Resorts = new HashSet<Resort>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Resort> Resorts { get; set; }
    }
}
