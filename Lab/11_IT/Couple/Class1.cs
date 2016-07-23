using System.Collections;

namespace Couple
{
    public class Class1:IEnumerable
    {
        static ArrayList myArray = new ArrayList();

        public Class1()
        {
            for (int i = 0; i <= 100; i++)
                if (i % 2 == 0)
                    myArray.Add(i);
                    //Console.Write(i+", ");
        }

        public IEnumerator GetEnumerator()
        {
            return myArray.GetEnumerator();
        }
    }
}
