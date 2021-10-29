using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Worker
    {
        public Worker()
        {
            Orderings = new HashSet<Ordering>();
        }

        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int CardId { get; set; }
        public int CodeId { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? Wage { get; set; }

        public double Bonus { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Ordering> Orderings { get; set; }
    }
}
