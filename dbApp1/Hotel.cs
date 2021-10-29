using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Hotel
    {
        public Hotel()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? ResortId { get; set; }
        public string Name { get; set; }
        public int StarsNumber { get; set; }
        public string Room { get; set; }
        public bool? Safe { get; set; }
        public bool? Conditioner { get; set; }
        public bool? WiFi { get; set; }
        public string Bed { get; set; }
        public bool? MiniBar { get; set; }

        public virtual Resort Resort { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
