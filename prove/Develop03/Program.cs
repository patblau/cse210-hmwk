using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var repo = new ScriptRepository();
        var menu = new Menu(repo);

        while (true)
        {
            // Pick which collection (Old/New Testament, etc.)
            var work = menu.PromptStandardWork();
            if (work == StandardWork.None) return;

            // Difficulty = how many words to hide each step
            int hideCount = menu.PromptDifficulty();

            // Pick a scripture from that collection (or random)
            var chosen = menu.PromptScriptureChoice(work);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(chosen.Reference);
                Console.WriteLine();
                scripture.DisplayInline();

                Console.WriteLine("\n\nPress Enter to hide more | type 'switch' to choose another | 'quit' to exit");
                Console.Write("> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    scripture.HideRandomWords(hideCount);

                    if (scripture.AllHidden())
                    {
                        Console.Clear();
                        Console.WriteLine(chosen.Reference);
                        Console.WriteLine();
                        scripture.DisplayInline();
                        Console.WriteLine("\n\nAll words hidden. Press Enter to continue...");
                        Console.ReadLine();
                        break; // go back to menu
                    }

                    continue;
                }
                input = input.Trim().ToLower();
                if (input == "quit") return;
                if (input == "switch") break; // choose a different scripture

                // default: hide more
                scripture.HideRandomWords(hideCount);
            }
        }
    }
}

              