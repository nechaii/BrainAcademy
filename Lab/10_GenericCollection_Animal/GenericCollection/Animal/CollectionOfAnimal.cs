using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class CollectionOfAnimal<T> 
        where T: Animal, new()
    {
        public ArrayList animal = null;

        public CollectionOfAnimal()
        {
            animal = new ArrayList();
        }

        public void AddAnimal(object obj)
        {
            if (obj is Animal)
                animal.Add(obj);
        }

        public void Sort()
        {
            animal.Sort();
        }

        public void SortByWeight()
        {
            animal.Sort(AnimalSortWeight.SortWeight);

        }

        public void SortByTypeEnimal()
        {
            animal.Sort(AnimalSortTypeEnimal.SortTypeEnimal);
        }
    }
}
