using System;


namespace ConsoleApplication1
{
    using CarCollection;
    using ClassLibrary1;
    using Couple;
    using Polindrom;

    class Program
    {
        static void Main(string[] args)
        {
            ///*Reverse array*/
            //ClassLibrary1.Class1 myClass = new ClassLibrary1.Class1();
            //int[] arr = { 1, 3, 2, 7, 6, 5 };
            //for (int i = 0; i < arr.Length; i++)
            //    Console.WriteLine(arr[i]);
            //Console.WriteLine(new string('-', 50));
            //myClass.MyReverse<int>(ref arr);
            //for (int i = 0; i < arr.Length; i++)
            //    Console.WriteLine(arr[i]);

            ///*IEnumerable*/
            //CarCollections myCollection = new CarCollections();
            //foreach (var p in myCollection)
            //    Console.WriteLine(p);

            ///*Pair numbers*/
            //Couple.Class1 myCouple = new Couple.Class1();
            //foreach (var p in myCouple)
            //    Console.Write(p +", ");

            Polindr myPolindrom = new Polindrom.Polindr();
            //myPolindrom.CheckPolindrom("ollo");
            myPolindrom.CheckPolindrom("werter");
            
                    


            Console.ReadKey();

        }
    }
}
