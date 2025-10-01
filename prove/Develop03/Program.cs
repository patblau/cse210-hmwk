using System;

namespace Develop03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Choose the verse you want to practice:
            // John 3:16
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so loved the world, that he gave his only begotten Son, " +
                          "that whosoever believeth in him should not perish, but have everlasting life.";

            // Or Proverbs 3:5–6 (uncomment to use)
            // Reference reference = new Reference("Proverbs", 3, 5, 6);
            // string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            //               "In all thy ways acknowledge him, and he shall direct thy paths.";

            Scripture scripture = new Scripture(reference, text);

            while (true)
            {
                scripture.Display();
                Console.WriteLine();
                Console.Write("Press Enter to hide words (type 'quit' to exit): ");
                string input = Console.ReadLine();
                if (input != null && input.Trim().ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3); // change 3 for difficulty

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