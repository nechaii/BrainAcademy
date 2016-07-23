using System;

namespace Geometric_figures
{
    class Triangle:Shape
    {
        double sideA;
        double sideB;
        double sideC;
        double radiusInsideTriangle;

        public double SideA
        {
            get { return sideA; }
            set { sideA = value; }
        }

        public double SideB
        {
            get { return sideB; }
            set { sideB = value; }
        }

        public double SideC
        {
            get { return sideC; }
            set { sideC = value; }
        }

        double RadiusInsideTriangle {
            get
            {

                double p = (this.sideA + this.sideB + this.sideC) / 2;
                return Math.Sqrt(((p - this.sideA) * (p - this.sideB) * (p - this.sideC))/p);
            }
        }

        public Triangle():base("Triangle")
        {
            this.sideA = this.sideB = this.sideC = 1;
        }

        public Triangle(string name, double sideA, double sideB, double sideC) : base(name)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        sealed public override double CalcShapeArea()
        {
            return (this.sideA * this.sideB * this.sideC)/ (4 * RadiusInsideTriangle);
        }

        sealed public override double CalcShapeLength()
        {
            return (this.sideA + this.sideB + this.sideC);
        }
    }
}
