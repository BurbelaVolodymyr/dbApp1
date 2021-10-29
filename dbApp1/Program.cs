using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dbApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {

                //Country c1 = new Country { Name = "Greece" };     //додавання
                //db.Countries.Add(c1);
                //db.SaveChanges();

                var countries = db.Countries.ToList();
                Console.WriteLine("Country:");
                foreach (Country c in countries)
                {
                    Console.WriteLine($"{c.Name}");
                }


                //var o1 = db.Orderings.Where(p => p.ClientId == 3);    //видалення
                //db.Orderings.Remove(o1);
                //db.SaveChanges();

                var orderings = db.Orderings.ToList();
                Console.WriteLine("\nOrdering:");
                foreach (Ordering o in orderings)
                {
                    Console.WriteLine($"{o.ClientId}, {o.WorkerId}, {o.TicketNumber}");
                }


                //Care c1 = db.Cares.FirstOrDefault();    //зміна
                //if (c1 != null)
                //{
                //    c1.Cost = 1600;
                //    db.Cares.Update(c1);
                //    db.SaveChanges();
                //}

                var cares = db.Cares.ToList();
                Console.WriteLine("\nHotel:");
                foreach (Care c in cares)
                {
                    Console.WriteLine($"{c.TicketId}, {c.Name}, {c.Cost}");
                }
            }
            Console.ReadKey();
        }
    }
}
