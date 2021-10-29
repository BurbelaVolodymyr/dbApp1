using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Ordering
    {
        public Ordering()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? WorkerId { get; set; }
        public int TicketNumber { get; set; }

        public virtual Client Client { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
