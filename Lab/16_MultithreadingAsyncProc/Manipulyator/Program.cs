using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Manipulyator
{
    class MyClass
    {
        public Thread[] threadArray = null;

        public void Add1()
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Add1 Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void Add2()
        {
            
            for (int i = 0; i < 200; i++)
            {
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Add2 Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void Stop(object th)
        {
            var f = th as Thread;
            while (true)
            {    
                if (Console.ReadKey().Key == ConsoleKey.W)
                {
                    Console.WriteLine("Aborted ADD1");
                    Thread.Sleep(200);
                    threadArray[0].Abort();
                    threadArray[1].Abort();
                }

                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    Console.WriteLine("Aborted ADD2");
                    Thread.Sleep(200);
                    threadArray[2].Abort();
                }

                if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    Console.WriteLine("Exit!!!");
                    Thread.Sleep(2000);
                    //f.Abort();
                    Thread.CurrentThread.Abort();                    
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            ThreadStart methodAdd = new ThreadStart(myClass.Add1);

            Thread thread1 = new Thread(methodAdd);            
            Thread thread2 = new Thread(methodAdd);
            Thread thread3 = new Thread(myClass.Add2);

            Thread[] threadArray = { thread1, thread2, thread3 };
            myClass.threadArray = threadArray;

            thread1.IsBackground = true;
            thread1.Start();

            thread2.IsBackground = true;
            thread2.Start();

            thread3.IsBackground = true;
            thread3.Start();

            Thread threadStop = new Thread(myClass.Stop);
            threadStop.IsBackground = false;
            threadStop.Start(Thread.CurrentThread);
        }
    }
}
