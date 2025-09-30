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
            // Required calculations: sum, average, largest number
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
        
            //Find the smallest positive number
            int smallestPositive = numbers.Where(n => n > 0).Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        } 
