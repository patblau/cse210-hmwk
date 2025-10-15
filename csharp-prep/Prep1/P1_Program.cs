using System;
class Program
{
    static void Main(string[] args)
	{
		// Greet the user

	 	Console.WriteLine("Hello there!");

        // Ask for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Ask for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display full name in format: "Your name is Last, First Last."
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}

