using System;

namespace Geometric_figures
{
    abstract class Shape : ICalculateShape, IDisplayShape
    {
        private string shapeName;

        public Shape() : this("Shape")
        { }

        public Shape(string name)
        {
            this.shapeName = name;
        }

        public string ShapeName
        {
            get { return this.shapeName; }
            set { this.shapeName = value; }
        }

        public virtual double CalcShapeArea()
        {
            return 1;
        }

        public virtual double CalcShapeLength()
        {
            return 1;
        }

        public void PrintShapeArea()
        {
            Console.WriteLine("My Area is:{0}", CalcShapeArea().ToString());
        }

        public void PrintShapeLength()
        {
            Console.WriteLine("My length is:{0}", CalcShapeLength().ToString());
        }

        public void PrintShapeName()
        {
            Console.WriteLine("My nmae is:{0}", this.shapeName);
        }

    }
}
