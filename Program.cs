using System;
using System.Collections.Generic;
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
            Console.WriteLine("12" + "3"); //should spit out 123
            Console.WriteLine(2 * 3);         // Basic Arithmetic: +, -, /, *
            Console.WriteLine(10 % 3);        // Modulus Op => remainder of 10/3
            Console.WriteLine(1 + 2 * 3);     // order of operations
            Console.WriteLine(10 / 3.0);      // int's and doubles
            Console.WriteLine(10 / 3);        // int's 


            int num = 10;
            num += 100;
            Console.WriteLine(num);
            num++;
            Console.WriteLine(num);

            bool isCold = true;
            Console.WriteLine(isCold ? "drink" : "add ice");
            Console.WriteLine(!isCold ? "drink" : "add ice");
            string stringNum = "2";
            Console.WriteLine(stringNum);
            Int32 numString = Convert.ToInt32(stringNum);
            Console.WriteLine($"{numString}, {numString.GetType()}");
            Dictionary<string, int> myScoreBoard = new Dictionary<string, int>() { 
            { "firstInning", 10},
            { "secondInning", 20},
            { "thirdInning", 30 },};
            myScoreBoard.Add("fourthInning", 40);
            myScoreBoard.Add("fifthInning", 50);

            Console.WriteLine("------------");
            Console.WriteLine(" Scoreboard ");
            Console.WriteLine("------------");
            Console.WriteLine("Inning | Score");
            Console.WriteLine("   1   | {0}", myScoreBoard["firstInning"]);
            Console.WriteLine("   2   | {0}", myScoreBoard["secondInning"]);
            Console.WriteLine("   3   | {0}", myScoreBoard["thirdInning"]);
            Console.WriteLine("   4   | {0}", myScoreBoard["fourthInning"]);
            Console.WriteLine("   5   | {0}", myScoreBoard["fifthInning"]);
            string[] favFoods = new string[3] { "pizza", "doughnuts", "icecream" };
            string firstFood = favFoods[0];
            string secondFood = favFoods[1];
            string thirdfood = favFoods[2];
            Console.WriteLine("i like {0}, {1}, and {2}", firstFood, secondFood, thirdfood);
            List<string> employees = new List<string>() { "adam", "amy" };

            employees.Add("barbara");
            employees.Add("billy");
            Console.WriteLine("My employees include {0}, {1}, {2}, {3}", employees[0], employees[1], employees[2], employees[3]);
            for (int i = 0; i<employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
    }
}