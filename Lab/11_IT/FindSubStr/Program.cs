using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubStr
{
    static class MyClass
    {
        public static void WordPosition(this String str, string subStr)
        {
            char[] tmpArray = str.ToCharArray();
            char[] tmpSubStr = subStr.ToCharArray();

            for (int i = 0, j = 0; i < tmpArray.Length; i++)
            {
                if (tmpArray[i] == tmpSubStr[j])
                {
                    if (j == tmpSubStr.Length - 1)
                    {
                        int flag = i - j;
                        Console.WriteLine("Substring {0} was foun in word {1} on position {2}: ",subStr,str,flag);
                        break;
                    }

                    j++;
                    continue;
                }
                j = 0;
            }                
        }

        public static void RemoveSpace(this String str)
        {
            char[] tmpArray = str.ToCharArray();
            string tmp ="";

            for (int i = 0; i < tmpArray.Length; i++)
            {
                if (tmpArray[i] != ' ')
                {
                    tmp += tmpArray[i];  
                }                    
            }
            Console.WriteLine(tmp);
        }

        public static void UpperLitrWords(this String str)
        {
            char[] tmpArray = str.ToCharArray();
            string tmp = "";
            int flag=0;

            for (int i = 0; i < tmpArray.Length; i++)
            {
                if (flag == 1 )
                {
                    tmp += char.ToUpper(tmpArray[i]);
                    flag = 0;
                    continue;
                }

                if (tmpArray[i] == ' ')
                {
                    flag++;
                }

                if (i == 0)
                {
                    tmp += char.ToUpper(tmpArray[i]);
                }

                if (i != 0)
                {
                    tmp += tmpArray[i];
                }
                
            }
            Console.WriteLine(tmp);
        }
    }


    class Program
    {       

        static void Main(string[] args)
        {
            "Werter".WordPosition("rt");
            "Petro".WordPosition("ro");
            "Pinokio".WordPosition("ino");

            "Hellow World".RemoveSpace();
            "hellow my friends".UpperLitrWords();

            Console.ReadKey();
        }
    }
}
