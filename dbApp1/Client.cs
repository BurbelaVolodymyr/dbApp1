using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Client
    {
        public Client()
        {
            Orderings = new HashSet<Ordering>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CardId { get; set; }
        public int? PhoneNumber { get; set; }

        public virtual ICollection<Ordering> Orderings { get; set; }
    }
}
