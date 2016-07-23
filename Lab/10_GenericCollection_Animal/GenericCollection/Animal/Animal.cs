using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Animal : IComparable
    {
        public double MaxSpead { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }

        public EnumAnimal TypeEnimal { get; set; }

        public Animal()
        { }

        public int CompareTo(object obj1)
        {
            var obj = obj1 as Animal;
   
            if (this.MaxSpead > obj.MaxSpead)
                return 1;
            else if (this.MaxSpead < obj.MaxSpead)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Type: {1}, Waight: {2}, MaxSpead: {3}",this.Name, this.TypeEnimal,this.Weight, this.MaxSpead);
        }
    }
}
