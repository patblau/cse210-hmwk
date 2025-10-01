using System;

namespace Develop03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example scripture: Proverbs 3:5–6
            var reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                          "In all thy ways acknowledge him, and he shall direct thy paths.";

            var scripture = new Scripture(reference, text);

            while (true)
            {
                scripture.Display();
                Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                scripture.HideRandomWords(3); // adjust this number for difficulty

                if (scripture.AllHidden())
                {
                    scripture.Display();
                    Console.WriteLine("\nAll words hidden. Program ending...");
                    break;
                }
            }
        }
    }
}
