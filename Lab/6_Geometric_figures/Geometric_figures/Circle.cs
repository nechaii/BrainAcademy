using System;

namespace Geometric_figures
{
    class Circle : Shape
    {
        double radius; 

        public double Radius {
            get; set;
        }

        public Circle():base("Circle")
        {
            radius = 1;
        }

        public Circle(string name) : base(name)
        {
            radius = 1;
        }

        public Circle(string name, double rad) : base(name)
        {
            this.radius = rad;
        }

        public override double CalcShapeArea()
        {
            return Math.Pow(this.radius, 2) * Math.PI;
        }

        public override double CalcShapeLength()
        {
            return Math.PI * 2 * this.radius;
        }
    }
}
