namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Rectangle(2.5, 8.9);

            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.Draw());

            shape = new Circle(6.5);

            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.Draw());
        }
    }
}