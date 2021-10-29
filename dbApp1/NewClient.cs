using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class NewClient
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string HotelName { get; set; }
        public string ResortName { get; set; }
        public DateTime? FirstTime { get; set; }
        public DateTime? SecondTime { get; set; }
        public int NumTicket { get; set; }
    }
}
