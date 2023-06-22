using System;
namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = "Hello";
            greeting = greeting + "World";
            Console.WriteLine($"greeting: {greeting}");
            Console.WriteLine("greeting: {0}", greeting);

            //How do i find the area of a square? area = side times side
            double side = 3.14;
            double area = side * side;
            Console.WriteLine(area);
            Console.WriteLine("area is a {0}", area.GetType().Name);
        }
    }
}