namespace Geometric_figures
{
    class Rectangle : Square
    {
        public Rectangle()
        {
        }

        public Rectangle(string name, double sideA, double sideB) : base(name, sideA, sideB)
        {

        }

        public override double CalcShapeArea()
        {
            return base.CalcShapeArea();
        }

        sealed public override double CalcShapeLength()
        {
            return base.CalcShapeLength();
        }
    }
}
