using System;

class Program
{
    static void Main(string[] args)
    {
		Console.WriteLine("Hello World!");
		Console.Write("What is your last name? ");
		string lastName = Console.ReadLine();

		Console.Write("What is your favorite color? ");
		string color = Console.ReadLine();
		Console.WriteLine($"Your favorite color is {color}");

		int number = 5;
		number = 8;
		number = number + 3;

		string anotherColor = "blue";
		if (number > 3)
		{
			Console.WriteLine("Number is greater than 3.");
		}
	}
}
