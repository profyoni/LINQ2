using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
       // [STAThread]
        static void Main()
        {
            // LINQ to objects (in memory) - all LINQ executed in C# runtime on your CPU, locally, very fast (no network latency)
            // LINQ to entities (= tables in a database) - LINQ query is converted into SQL and sent to the database, and executed on database
            //   Pro - query is run on SQL Server (RDBMS) which is optimized for queries,
            //         data resides in db  and query run in same DB,
            //         only results sent to C# program
            //   Con - some ops cannot be converted easily or at all to SQL (if you call a C# function it is c# , not SQL)
            //         SQL may be very unoptimized, might be O(n^2) where it should be O(n)
            //         each request may suffer latency accessing database especially with
            //              enumerables (with yield/deferred execution) that require a round trip to db for each record returned
            //     Best used for simple queries and for getting started
            //     for complex queries after Proof of Concept optimize as needed (SQL functions, procedures, LINQ optimizations)

            // Early optimization is the root of all evil (Donald Knuthe)

            // LINQ to XML (xml representation of data, JSON has to a great extend replaced XML)
               // XML / JSON will be deserialized into an object during a web service API call e.g. Azure Language Service
        
               // Specify the data source.

               // MoreLINQ

               // letter frequency histogram




            var scores = Enumerable.Range(1, 100_000_000); // new int[] { 97, 92, 81, 60 };

            var people = scores.Select(id => GetPersonById(id));

            IEnumerable<PersonProjection> firstNameLastName = people
                .Select(p => new PersonProjection { Firstname = p.First, LastName = p.Last})
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.LastName)
               ;// .GroupBy();
            
            var s = firstNameLastName.First().ToString();

            // Define the query expression.
            IEnumerable<int> scoreQuery = 
                scores.Where(IsEven)
                    .OrderByDescending(x => Math.Sqrt(x))
                      .Take(100); // MoreLinq

                // from score in scores
                // where score % 2 == 0
                // select score;

            // LINQ uses deferred execution
            // JIT execution, lazy evaluation
            // is awfully slow and ineffiecient when the data is not in memory
            // e.g. if the data is in a database and each object needs a round trip
            // to the db to be generated
            // to force eager evaluation, call ToList();

            // Execute the query.
            foreach (int i in scoreQuery.Take(100).ToList())
            {
                Console.Write(i + " ");
                if (i > 100)
                    break;
            }

            Console.WriteLine("End");
            // Application.SetHighDpiMode(HighDpiMode.SystemAware);
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
        }

        private static Person GetPersonById(int id)
        {
            return new Person()
            {
                Id = id,
                First = id % 10 + "",
                Last = id+"",
                EyeColor = Color.FromArgb(id, id, id),
                Importance = (Importance) (id % ((int)Importance.Engineer+1))
            };
        }
    }
    class PersonProjection
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
    }

    class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public Color EyeColor { get; set; }
        public Importance Importance { get; set; }
    }

    enum Importance {NonSet, Loser, Manager, MediumRank, VIP, Engineer}
}
