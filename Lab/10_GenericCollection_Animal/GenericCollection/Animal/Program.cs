using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionOfAnimal<Animal> myCollectionOfAnimal = new CollectionOfAnimal<Animal>();

            myCollectionOfAnimal.AddAnimal(new Animal() { TypeEnimal = EnumAnimal.Mouse, MaxSpead = 10, Weight = 1, Name = "Miky" });
            myCollectionOfAnimal.AddAnimal(new Animal() { TypeEnimal = EnumAnimal.Duck, MaxSpead = 5, Weight = 10, Name = "Donald" });
            myCollectionOfAnimal.AddAnimal(new Animal() { TypeEnimal = EnumAnimal.Camel, MaxSpead = 20, Weight = 300, Name = "Camel" });
            myCollectionOfAnimal.AddAnimal(new Animal() { TypeEnimal = EnumAnimal.Elefant, MaxSpead = 50, Weight = 200, Name = "Dumbo" });
            myCollectionOfAnimal.AddAnimal(new Animal() { TypeEnimal = EnumAnimal.Lione, MaxSpead = 70, Weight = 100, Name = "LionKing" });

            foreach (var p in myCollectionOfAnimal.animal)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine(new string('-',50));
            myCollectionOfAnimal.Sort();

            foreach (var p in myCollectionOfAnimal.animal)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine(new string('-', 50));
            myCollectionOfAnimal.SortByWeight();

            foreach (var p in myCollectionOfAnimal.animal)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine(new string('-', 50));
            myCollectionOfAnimal.SortByTypeEnimal();

            foreach (var p in myCollectionOfAnimal.animal)
            {
                Console.WriteLine(p.ToString());
            }

            Console.ReadKey();
        }
    }
}
