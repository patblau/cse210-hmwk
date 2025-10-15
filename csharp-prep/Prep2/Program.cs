using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello there!");

        // Ask for first and last name
        Console.Write("What is your name? ");
        string firstName = Console.ReadLine();

        // Display formatted name
        Console.WriteLine($"\n{firstName}.");

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
            
            // Guessing loop
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");   

                    // Ask to play again
                    Console.Write("Would you like to play again? (yes/no) ");
                    playAgain = Console.ReadLine().ToLower();
                    if (playAgain != "yes")
                    
                    Console.WriteLine("Thanks for playing! Goodbye.");          
                }
            }
        }
    }
}