using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("John", 3, 16);
        string text = "For God so loved the world, that he gave his only begotten Son, " +
                      "that whosoever believeth in him should not perish, but have everlasting life.";

        var scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(reference);
            Console.WriteLine();
            scripture.DisplayInline();
            Console.WriteLine("\nPress Enter to hide words (type 'quit' to exit):");
            var input = Console.ReadLine();
            if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase)) break;

            scripture.HideRandomWords(3);
            if (scripture.AllHidden())
            {
                Console.Clear();
                Console.WriteLine(reference);
                Console.WriteLine();
                scripture.DisplayInline();
                Console.WriteLine("\nAll words hidden. Program ending...");
                break;
            }
        }
    }
}