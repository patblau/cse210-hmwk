using System;
using System.Collections.Generic;

public class Menu
{
    private readonly ScriptureRepository _repo;

    public Menu(ScriptureRepository repo)
    {
        _repo = repo;
    }

    // Which collection to pull from?
    // Returns StandardWork.None if user wants to quit 
    public StandardWork PromptStandardWork()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Scripture Memorizer ===\n");
            Console.WriteLine("Select a collection:");
            Console.WriteLine("1) Old Testament");
            Console.WriteLine("2) New Testament");
            Console.WriteLine("3) Book of Mormon");
            Console.WriteLine("4) Doctrine and Covenants");
            Console.WriteLine("5) Pearl of Great Price");
            Console.WriteLine("Q) Quit");
            Console.Write("\nChoice: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            input = input.Trim().ToLower();
            if (input == "q" || input == "quit") return StandardWork.None;

            if (input == "1") return StandardWork.OldTestament;
            if (input == "2") return StandardWork.NewTestament;
            if (input == "3") return StandardWork.BookOfMormon;
            if (input == "4") return StandardWork.DoctrineAndCovenants;
            if (input == "5") return StandardWork.PearlOfGreatPrice;
        }
    }

    // How many words to hide per step
    public int PromptDifficulty()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("How many words to hide each step?");
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
