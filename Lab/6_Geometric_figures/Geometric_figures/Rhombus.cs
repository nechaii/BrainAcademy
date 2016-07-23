using System;

namespace Geometric_figures
{
    class Rhombus : Square
    {
        byte coner;

        public Rhombus()
        {
        }

        public Rhombus(string name, double sideA, double sideB, byte coner) : base(name, sideA, sideB)
        {
            this.coner = coner;
        }

        public override double CalcShapeArea()
        {
            return base.CalcShapeArea()*Math.Sin(this.coner);
        }

        sealed public override double CalcShapeLength()
        {
            return base.CalcShapeLength();
        }
    }
}
