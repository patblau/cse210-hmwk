using System;

class Program
{
    static void Main(string[] args)
    {
		Console.WriteLine("Hello there!");

		// Ask for first name
		Console.Write("What is your last name? ");
		string lastName = Console.ReadLine();

		// Ask for last name
		Console.Write("What is your last name? ");
		string firstName = Console.ReadLine();

		// Display full name
		Console.WriteLine($"Your name is, {lastName}.");
		Console.WriteLine($"{lastName}, {firstName} {lastName}.");
	}	
}		