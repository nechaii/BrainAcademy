using System;

namespace Calculyator
{
    public delegate void MathOperation(double x, double y);

    class Program
    {
        static event MathOperation doSomesing;

        static void Main(string[] args)
        {
            MathOperation myMathOperation = null;

            while (true)
            {
                Console.WriteLine("Enter value for x");
                double x;
                double.TryParse(Console.ReadLine(), out x);

                Console.WriteLine("Enter value for y");
                double y;
                double.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Enter operation *,/,-,+");

                switch (Console.ReadLine())
                {
                    case "-":
                        {
                            myMathOperation = Calculate.Sub;
                        }
                        break;

                    case "+":
                        {
                            myMathOperation = Calculate.Sum;
                        }
                        break;

                    case "/":
                        {
                            myMathOperation = Calculate.Div;
                        }
                        break;

                    case "*":
                        {
                            myMathOperation = Calculate.Mul;
                        }
                        break;

                    default:
                        {
                            doSomesing += (x1, y1) =>
                            {
                                Console.WriteLine("Wrong operation with {0},{1}", x1,y1);
                            };                           
                           
                        }
                        break;
                }

                if (myMathOperation != null)
                    myMathOperation(x, y);
                else
                {
                    doSomesing(x, y);
                }
            }            
        }
    }
}
