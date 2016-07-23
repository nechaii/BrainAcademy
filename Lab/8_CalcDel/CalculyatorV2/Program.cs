using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculyatorV2
{
    delegate void MathOperation(double x, double y);

    class CalculateV2
    {
        public void DoSomething(double x, double y, MathOperation myDel)
        {
            myDel(x,y);

            myDel+= (double x1, double y1) => { Console.WriteLine("Something shit");}; // будет добавлено в конец списка методо и вызоветься последним, то есть  myDel(2, 3); отработает раньше чем Console.WriteLine("Something shit")

            myDel(2, 3);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            CalculateV2 myCalculateV2 = new CalculateV2();

            MathOperation nn = null;
            nn += (double x, double y) => { Console.WriteLine(x + y); };
            nn += (double x, double y) => { Console.WriteLine(x - y); };
            nn += (double x, double y) => { Console.WriteLine(x / y); };
            nn += (double x, double y) => { Console.WriteLine(x * y); };

            myCalculateV2.DoSomething(8, 2, nn);

            foreach (var p in nn.GetInvocationList())
                Console.WriteLine(p.Method);

            Console.ReadKey();
        }
    }
}
