using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
                if (i % 3 == 0)
                    Console.Write("Fiz: " + i);
                else if (i % 5 == 0)
                    Console.Write("Buz: " + i);
                else if (i % 15 == 0)
                    Console.Write("FizBuz: " + i);
                else Console.WriteLine();

            Console.WriteLine();



            Console.ReadKey();


        }
    }
}
