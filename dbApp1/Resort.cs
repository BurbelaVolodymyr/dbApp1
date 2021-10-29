using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Resort
    {
        public Resort()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
