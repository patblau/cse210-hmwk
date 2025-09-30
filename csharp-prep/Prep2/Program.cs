using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello there!");

        // Ask for first and last name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display formatted name
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");

        // Main game loop (play again feature)
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes")
        { 
            // Generate random magic number (1–100)
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("\nI am thinking of a magic number between 1 and 100...");
}   