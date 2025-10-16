using System;
using System.Runtime.CompilerServices;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            DisplayMenu();
            string choice = GetUserChoice();

            Activity? activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _   => null
            };

            if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            if (activity == null)
            {
                Console.WriteLine("Please choose 1–4. Press ENTER to try again.");
                Console.ReadLine();
                continue;
            }

            activity.Run();

            Console.WriteLine("\nPress ENTER to return to the main menu…");
            Console.ReadLine();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("-------------------");
        Console.WriteLine("1) Breathing Activity");
        Console.WriteLine("2) Reflection Activity");
        Console.WriteLine("3) Listing Activity");
        Console.WriteLine("4) Quit");
        Console.Write("Select a choice from the menu: ");
    }

    private static string GetUserChoice()
    {
        return Console.ReadLine()?.Trim() ?? "";
    }
}
