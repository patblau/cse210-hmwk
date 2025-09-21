using System;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine();  // You forgot to store the last name

            Console.Write("What is your favorite color? "); 
            string color = Console.ReadLine();  // You had "Consol" instead of "Console"
            Console.WriteLine($"Your favorite color is {color}");

            int number = 5;   // Use lowercase "int", not "Int"
            number = 8;
            number = number + 3;

            color = "blue";

            if (number > 3)
            {
                Console.WriteLine($"{lastName}, since number is greater than 3, your color is {color}.");
            }
        }
    }
}