using System;
using System.Collections.Generic;
using System.Linq; // for helpful list methods like Min, Max, Average

class Program
{
    static void Main(string[] args)
    {
        // Request numbers from the user
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            userNumber = int.Parse(userInput);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } 
