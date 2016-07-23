using System;

namespace Geometric_figures
{
    sealed class Ellipse : Circle
    {
        double minRadius;
        double maxRadius;
        
        public double MinRadius {
            get { return minRadius; }
            set { minRadius = value; }
        }

        public double MaxRadius {
            get { return maxRadius; }
            set { maxRadius = value; }
        }

        public Ellipse():base("Ellipse")
        {
            minRadius = maxRadius = 1;
        }

        public Ellipse( string name, double minRadius, double maxRadius) : base(name)
        {
            this.minRadius = minRadius;
            this.maxRadius = maxRadius;
        }

        sealed public override double CalcShapeArea()
        {
            return Math.PI * (this.minRadius * this.maxRadius);
        }

        sealed public override double CalcShapeLength()
        {
            return Math.PI * (this.minRadius+this.maxRadius);
        }
    }
}
