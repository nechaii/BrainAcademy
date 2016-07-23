using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class AnimalSortWeight : IComparer
    {
        public static IComparer SortWeight = new AnimalSortWeight();

        public int Compare(object x, object y)
        {
            if (x is Animal && y is Animal)
            {
                if (((Animal)x).Weight > ((Animal)y).Weight)
                    return 1;
                else if (((Animal)x).Weight < ((Animal)y).Weight)
                    return -1;
            }
            return 0;
        }
    }

    class AnimalSortTypeEnimal : IComparer
    {
        public static IComparer SortTypeEnimal = new AnimalSortTypeEnimal();
        public int Compare(object x, object y)
        {
            if (x is Animal && y is Animal)
            {
                if (((Animal)x).TypeEnimal > ((Animal)y).TypeEnimal)
                    return 1;
                else if (((Animal)x).TypeEnimal < ((Animal)y).TypeEnimal)
                    return -1;
            }
            return 0;
        }
    }
}
