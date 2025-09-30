using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello Prep4 World!");
        }
            DisplayWelcome();

            string name = PromptUserName();
            int favoriteNumber = PromptUserNumber();

            PromptUserBirthYear(out int birthYear);

            int squaredNumber = SquareNumber(favoriteNumber);

            DisplayResult(name, squaredNumber, birthYear);
    }
}       