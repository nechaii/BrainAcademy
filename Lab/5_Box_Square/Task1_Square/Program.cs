using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            Square.startLeft = Console.CursorLeft;
            Square.startTop = Console.CursorTop;

            Square mySquare = new Square("Hellow", 20, 20);
            mySquare.WriteString();

            Square.startLeft = 30;
            Square.startTop = 0;

            mySquare = new Square("Duck tales", 60, 10);
            mySquare.WriteString();

            Square.startLeft = 30;
            Square.startTop = 12;

            mySquare = new Square("Mortal combat", 40, 10);
            mySquare.WriteString();

            Console.ReadKey();

        }
    }
}
