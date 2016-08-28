using SimpleRightInitializationDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRightInitializationDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ModelInitializer db = new ModelInitializer())
            { 
                db.Configuration.LazyLoadingEnabled = true;
                IQueryable<Group> gp = db.Groups;

                IEnumerable<Group> st = gp.ToList();

                foreach (var item in gp.Select(p => p.Student).FirstOrDefault())
                {
                    Console.WriteLine(item.FirstName);
                }
            }

            Console.ReadKey();

        }
    }
}
