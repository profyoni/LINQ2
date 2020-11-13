using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        static bool IsPrime(int n)
        {
            return n % 2 == 0;
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
       // [STAThread]
        static void Main()
        {

            // Specify the data source.
            var scores = Enumerable.Range(1, 100_000_000);//new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery = 
                scores.Where(IsPrime)
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
    }
}
