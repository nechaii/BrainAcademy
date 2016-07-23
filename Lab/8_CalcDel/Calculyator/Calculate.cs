using System;

namespace Calculyator
{
    static class Calculate
    {
        public static void Sum(double x, double y)
        {
            Console.WriteLine("Sum:{0}",x + y);
        }

        public static void Div(double x, double y)
        {
            Console.WriteLine("Div:{0}", x / y);
        }

        public static void Mul(double x, double y)
        {
            Console.WriteLine("Mul:{0}", x * y);
        }

        public static void Sub(double x, double y)
        {
            Console.WriteLine("Sub:{0}", x - y);
        }
    }
}
