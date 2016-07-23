using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCollection
{
    public class CarCollections:IEnumerable
    {
        ArrayList myCar = null;

        public CarCollections()
        {
            myCar = new ArrayList();
            myCar.Add(new Car() { Name = "Ford" });
            myCar.Add(new Car() { Name = "Merin" });
            myCar.Add(new Car() { Name = "BMW" });
            myCar.Add(new Car() { Name = "ZAZ" });
        }


        public IEnumerator GetEnumerator()
        {
            foreach (var p in myCar)
                yield return p;
        }
    }
}
