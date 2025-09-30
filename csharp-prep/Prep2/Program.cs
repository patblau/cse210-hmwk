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
    }   