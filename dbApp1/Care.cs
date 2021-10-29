using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Care
    {
        public int Id { get; set; }
        public int? TicketId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
