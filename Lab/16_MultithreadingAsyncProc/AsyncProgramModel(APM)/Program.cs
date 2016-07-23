using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramModel_APM_
{
    delegate int MyDelegate(int a);

    public class AsyncMyClass
    {        
        public int Factorial(int a)
        {
            Console.WriteLine("Thread: {0}, num: {1}", Thread.CurrentThread.ManagedThreadId, a);
            if (a > 1)
                return Factorial(a - 1) * a;

            Thread.Sleep(500);
            return 1;
        }

        public void EndCalc(IAsyncResult ar)
        {
            Console.WriteLine("Calc Completed" +"thread "+ Thread.CurrentThread.ManagedThreadId);           
        }
    }

    class Program
    {
        static object obj = new object();

        static void Main(string[] args)
        {
            AsyncMyClass myClass = new AsyncMyClass();
            MyDelegate delMethod = new MyDelegate(myClass.Factorial);

            IAsyncResult result = delMethod.BeginInvoke(4, new AsyncCallback(myClass.EndCalc) , obj);
            int returnValue = delMethod.EndInvoke(result);

            Console.WriteLine("Thread: {0}, num: {1}", Thread.CurrentThread.ManagedThreadId, returnValue);

            Console.ReadKey();
        }
    }
}
