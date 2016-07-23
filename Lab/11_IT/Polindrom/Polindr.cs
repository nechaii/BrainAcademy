using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polindrom
{
    using ClassLibrary1;

    public class Polindr
    {
        public void CheckPolindrom(string word)
        {
            ClassLibrary1.Class1 chkWord = new ClassLibrary1.Class1();            
            
            char[] tmpArr = word.ToUpper().ToCharArray();

            chkWord.MyReverse<char>(ref tmpArr);

            string tmpWord = new string(tmpArr);

            if (tmpWord == word.ToUpper())
                Console.WriteLine("Polindrom: " + word);
            else
                Console.WriteLine("Sorry:");
        }
    }
}
