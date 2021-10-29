using System;
using System.Collections.Generic;

#nullable disable

namespace dbApp1
{
    public partial class Company
    {
        public Company()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? WorkerNumber { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
