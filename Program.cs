using System;
using System.Collections.Generic;
namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
           List<string> employees = new List<string>();
            while (true)
            {
                Console.WriteLine("Please enter a name: (leave empty to exit)");
                string input = Console.ReadLine() ?? "";
                // break if the user hits enter without typing a name
                if (input == "" )
                {
                    break;
                }
                employees.Add(input);
            }

            for (int i = 0; i<employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
    }
}