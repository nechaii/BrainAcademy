namespace Geometric_figures
{
    class Square : Shape
    {
        double sideA;
        double sideB;

        public Square():base("Square")
        {
            sideA = sideB = 1;
        }

        public Square(string name, double sideA, double sideB) : base(name)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        public override double CalcShapeArea()
        {
            return this.sideA * this.sideB;
        }

        public override double CalcShapeLength()
        {
            return (this.sideA * 2) + (this.sideB * 2);
        }
    }
}
