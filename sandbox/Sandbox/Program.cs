using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        PromtUserBirthYear(out int birthYear);

        int squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(name, squaredNumber, birthYear);
    }

        static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to this Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("Enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

   



