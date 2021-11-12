using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace dbApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var resorts = (from Resort in db.Resorts.Include(p => p.Country)
                               where Resort.CountryId == 2
                               select Resort).ToList();

                foreach (var res in resorts)
                    Console.WriteLine($"{res.Country.Name} - {res.Name}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var resorts = (from Resort in db.Resorts
                               where Resort.Country.Name == "Turkey"
                               select Resort).ToList();

                Console.WriteLine("\nTurkey:");
                foreach (var res in resorts)
                    Console.WriteLine($"{res.Name}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var hots = db.Hotels.Where(p => EF.Functions.Like(p.Name, "%d%"));
                Console.WriteLine("\nHotel:");
                foreach (var hot in hots)
                    Console.WriteLine($"{hot.Name}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var cares = (from Care in db.Cares
                             select Care).ToList();
                Console.WriteLine("\nCare:");
                foreach (var ca in cares)
                    Console.WriteLine($"{ca.Id}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var clients = db.Clients.OrderBy(p => p.Name);
                Console.WriteLine("\nName:");
                foreach (var client in clients)
                    Console.WriteLine($"{client.Id}, {client.Surname} {client.Name}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var clients = from u in db.Clients
                              orderby u.Name
                              select u;

                Console.WriteLine("\nName:");
                foreach (var client in clients)
                    Console.WriteLine($"{client.Id}, {client.Surname} {client.Name}");
            }


            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var OrdClWor = from cli in db.Clients
                               join ord in db.Orderings on cli.Id equals ord.ClientId
                               join wor in db.Workers on ord.WorkerId equals wor.Id
                               select new
                               {
                                   ClientName = cli.Name,
                                   ClientSurname = cli.Surname,
                                   WorkId = ord.WorkerId,
                                   TicketNum = ord.TicketNumber,
                                   WorkerName = wor.Name,
                                   WorkerSurname = wor.Surname,
                               };

                Console.WriteLine("\nClientName ClientSurname - WorkId TicketNum - WorkerName WorkerSurname");
                foreach (var ocw in OrdClWor)
                    Console.WriteLine($"{ocw.ClientName} {ocw.ClientSurname} - {ocw.WorkId} {ocw.TicketNum} - {ocw.WorkerName} {ocw.WorkerSurname}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var CountRes = db.Resorts.Join(db.Countries,
                                       r => r.CountryId,
                                       c => c.Id,
                                       (r, c) => new
                                       {
                                           Resort = r.Name,
                                           Country = c.Name
                                       });

                Console.WriteLine("\nCountryResort:");
                foreach (var cr in CountRes)
                    Console.WriteLine($"{cr.Country} - {cr.Resort}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var worker = from work in db.Workers
                             group work by work.Company.Name into q
                             select new
                             {
                                 q.Key,
                                 Count = q.Count()
                             };

                Console.WriteLine("\nComapany - Worker");
                foreach (var n in worker)
                {
                    Console.WriteLine($"{n.Key} {n.Count}");
                }
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var worker = db.Workers.GroupBy(u => u.Company.Name).Select
                    (q => new
                    {
                        q.Key,
                        Count = q.Count()
                    });

                Console.WriteLine("\nComapany - Worker");
                foreach (var n in worker)
                {
                    Console.WriteLine($"{n.Key} {n.Count}");
                }
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                int sum = db.Cares.Where(u => u.TicketId == 1).Sum(s => s.Cost);
                Console.WriteLine($"\nPrice for num1 = {sum}");

                int minStar = db.Hotels.Min(h => h.StarsNumber);
                Console.WriteLine($"Min hotel stars = {minStar}");

                int maxStar = db.Hotels.Max(h => h.StarsNumber);
                Console.WriteLine($"Max hotel stars = {maxStar}");

                var avgWage = db.Workers.Average(p => p.Wage);
                Console.WriteLine($"AVG wage worker = {avgWage}");

                var curbed1 = db.Hotels.Any(u => u.Bed == "2 single");
                Console.WriteLine($"Any 2 single bed in hotel = {curbed1}");

                var curbed2 = db.Hotels.All(u => u.Bed == "1 double");
                Console.WriteLine($"All 3 double bed in hotel = {curbed2}");

                int numb = db.Companies.Count();
                Console.WriteLine($"Number of company = {numb}");

            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var users1 = db.Clients.Select(p => new { Name = p.Name }).Union(db.Workers.Select(c => new { Name = c.Name }));
                Console.WriteLine("\nUnion Name:");
                foreach (var us1 in users1)
                    Console.WriteLine($"{us1.Name}");

                var users2 = db.Clients.Select(p => new { Name = p.Name }).Intersect(db.Workers.Select(c => new { Name = c.Name }));
                Console.WriteLine("\nIntersect Name:");
                foreach (var us2 in users2)
                    Console.WriteLine($"{us2.Name}");

                var users3 = db.Clients.Select(p => new { Name = p.Name }).Except(db.Workers.Select(c => new { Name = c.Name }));
                Console.WriteLine("\nExcept Name:");
                foreach (var us3 in users3)
                    Console.WriteLine($"{us3.Name}");
            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@PrI", 1);
                var car = db.Cares.FromSqlRaw("SELECT * FROM TICPR (@PrI)", param).ToList();

                Console.WriteLine($"\n1) Id - TicketId - Name - Cost:");
                foreach (var u in car)
                    Console.WriteLine($"{u.Id} - {u.TicketId} - {u.Name} - {u.Cost}");

            }

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var tic = db.TICPR(2);

                Console.WriteLine($"\n2) Id - TicketId - Name - Cost:");
                foreach (var w in tic)
                    Console.WriteLine($"{w.Id} - {w.TicketId} - {w.Name} - {w.Cost}");
            }


            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var param = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@minWage",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 8000
                };
                db.Database.ExecuteSqlRaw("GetWage @minWage OUT", param);
                Console.WriteLine("\nЗаробітня плата звичайного працівника: {0}", param.Value);
            }
            */


            //захист
            //країну в яку найбільша кількість путівок продана

            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                var f1 = from tic in db.Tickets
                         join hot in db.Hotels on tic.HotelId equals hot.Id
                         join res in db.Resorts on hot.ResortId equals res.Id
                         join cou in db.Countries on res.CountryId equals cou.Id
                         select new
                         {
                             TicketHotel = tic.HotelId,
                             HotelId = hot.Id,
                             HotelName = hot.Name,
                             ResortName = res.Name,
                             CountryId = cou.Id,
                             CountryName = cou.Name,
                         };

                Console.WriteLine("\nTicketHotel - HotelId - HotelName - ResortName - CountryId - CountryName");
                foreach (var c1 in f1)
                    Console.WriteLine($"{c1.TicketHotel} - {c1.HotelId} - {c1.HotelName} - {c1.ResortName} - {c1.CountryId} - {c1.CountryName}");

                var f2 = from c in f1
                         group c by c.CountryId into g
                         select new { countryid = g.Key, CountId = g.Count() };

                foreach (var c2 in f2)
                    Console.WriteLine($"{c2.countryid} {c2.CountId}"); 

                var f3 = f2.Max(h => h.CountId);

                var countrylist = f2.Where(x => x.CountId == f3).Select(x => x.countryid).ToList();
                foreach (var countryid in countrylist)
                {
                    var f = db.Countries.Where(x => x.Id == countryid).FirstOrDefault().Name;
                    Console.WriteLine($"Найбільше їздили в {f} цілих {f3} раз");
                }

            }



            /*
            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {
                Country c1 = new Country { Name = "Greece" };     //додавання
                db.Countries.Add(c1);
                db.SaveChanges();

                var countries = db.Countries.ToList();
                Console.WriteLine("Country:");
                foreach (Country c in countries)
                {
                    Console.WriteLine($"{c.Name}");
                }
            }
            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {

                var o1 = db.Orderings.Where(p => p.ClientId == 3);    //видалення
                db.Orderings.Remove(o1);
                db.SaveChanges();

                var orderings = db.Orderings.ToList();
                Console.WriteLine("\nOrdering:");
                foreach (Ordering o in orderings)
                {
                    Console.WriteLine($"{o.ClientId}, {o.WorkerId}, {o.TicketNumber}");
                }
            }
            using (TRAVEL_AGENCYContext db = new TRAVEL_AGENCYContext())
            {

                Care c1 = db.Cares.FirstOrDefault();    //зміна
                if (c1 != null)
                {
                    c1.Cost = 1600;
                    db.Cares.Update(c1);
                    db.SaveChanges();
                }

                var cares = db.Cares.ToList();
                Console.WriteLine("\nHotel:");
                foreach (Care c in cares)
                {
                    Console.WriteLine($"{c.TicketId}, {c.Name}, {c.Cost}");
                }
            }
            */

            Console.ReadKey();
        }
    }
}
