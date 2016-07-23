using System;

namespace Geometric_figures
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] myShapes = { new Circle("MyCircle", 2), new Ellipse("MyEllipse", 2, 6), new Triangle("MyTriangle", 4, 4, 2), new Rectangle("MyRectangle", 4, 6), new Rhombus("MyRhombus", 4, 4, 45) };

            foreach (var p in myShapes)
            {
                Console.WriteLine(new string('*', 50));                
                p.PrintShapeName();
                p.PrintShapeArea();
                p.PrintShapeLength();
            }
            Console.ReadKey();
        }
    }
}
