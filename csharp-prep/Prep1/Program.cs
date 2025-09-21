using System;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Hello World!");
		Console.Write("What is your last name? ");

		Console.Write("What is your favorite color? ");
		string color = Console.ReadLine();
		Console.WriteLine($"Your favorite color is {color}");

		int number = 5;
		number = 8;
		number = number + 3;

		string favColor = "blue";
		if (number > 3)
		{
			// Do something if needed
		}
	}
}

