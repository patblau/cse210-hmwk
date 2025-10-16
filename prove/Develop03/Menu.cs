using System;

public class Menu
{
    private readonly ScriptRepository _repo;

    public Menu(ScriptRepository repo)
    {
        _repo = repo;
    }

    // Which collection to pull from?
    // Returns StandardWorks.None if user wants to quit 
    public StandardWorks PromptStandardWorks()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Scripture Memorizer ===\n");
            Console.WriteLine("Select a collection:");
            Console.WriteLine("1) Old Testament");
            Console.WriteLine("2) New Testament");
            Console.WriteLine("3) Book of Mormon");
            Console.WriteLine("4) Doctrine & Covenants");
            Console.WriteLine("5) Pearl of Great Price");
            Console.WriteLine("Q) Quit");
            Console.Write("\nChoice: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            input = input.Trim().ToLower();
            if (input == "q" || input == "quit") return StandardWorks.None;

            if (input == "1") return StandardWorks.OldTestament;
            if (input == "2") return StandardWorks.NewTestament;
            if (input == "3") return StandardWorks.BookOfMormon;
            if (input == "4") return StandardWorks.DoctrineAndCovenants;
            if (input == "5") return StandardWorks.PearlOfGreatPrice;
        }
    }

    // How many words to hide per step
    public int PromptDifficulty()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("How many words do you want to hide each step?");
            Console.WriteLine("1) Easy (1)");
            Console.WriteLine("2) Normal (3)");
            Console.WriteLine("3) Hard (5)");
            Console.WriteLine("Press Enter for Normal.");
            Console.Write("> ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return 3;

            input = input.Trim();
            if (input == "1") return 1;
            if (input == "2") return 3;
            if (input == "3") return 5;
        }
    }

    // Pick a scripture from that collection, do Random, go Back)
    //    Note: returns null when the user chooses "Back".
    public ScriptInfo PromptScriptureChoice(StandardWorks work)
    {
        var options = _repo.GetByStandardWorks(work);
        if (options.Count == 0) return null;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Select a scripture ({work}):\n");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {options[i].Reference}");
            }
            Console.WriteLine("R) Random");
            Console.WriteLine("B) Back");
            Console.Write("\nChoice: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            input = input.Trim().ToLower();
            if (input == "b" || input == "back") return null;
            if (input == "r" || input == "random") return _repo.GetRandom(work);

            int idx;
            if (int.TryParse(input, out idx))
            {
                if (idx >= 1 && idx <= options.Count) return options[idx - 1];
            }
        }
    }
}