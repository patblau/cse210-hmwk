// Program.cs
// Daily Journal Application

using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    
    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return "Date: " + Date + "\nPrompt: " + Prompt + "\nResponse: " + Response + "\n" + new string('-', 40);
    }
}

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I most grateful for today?",
            "What challenge did I overcome today?",
            "What did I learn today?",
            "How did I make someone else's day better?",
            "What is one thing I can improve on tomorrow?",
            "How did I grow as a person today?",
            "What made me smile today?",
            "What is something new I tried today?",
            "What is a goal I have for tomorrow?",
            "What is something I accomplished today?",
            "What is a habit I want to develop?",
            "What is something I want to let go of?",
            "What is a dream I have for the future?",
            "What is something I appreciate about myself?",
            "What is something I can do to take care of myself tomorrow?"

        };
    }

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        Console.WriteLine("\n=== JOURNAL ENTRIES ===");
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine("Entry " + (i + 1) + ":");
            Console.WriteLine(_entries[i]);
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.Date + "~|~" + entry.Prompt + "~|~" + entry.Response);
                }
            }
            Console.WriteLine("Journal saved to " + filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving: " + ex.Message);
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found: " + filename);
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                if (parts.Length >= 3)
                {
                    Entry entry = new Entry(parts[1], parts[2]);
                    entry.Date = parts[0];
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded from " + filename + ". " + _entries.Count + " entries loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading: " + ex.Message);
        }
    }

    public List<Entry> SearchEntries(string keyword)
    {
        List<Entry> results = new List<Entry>();
        foreach (Entry entry in _entries)
        {
            if ((entry.Prompt != null && entry.Prompt.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) ||
                (entry.Response != null && entry.Response.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                results.Add(entry);
            }
        }
        return results;
    }
}

class Program
{
    private static Journal journal = new Journal();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Daily Journal Application ===\n");
        
        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayAllEntries();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }

    static void WriteNewEntry()
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        Entry newEntry = new Entry(prompt, response);
        journal.AddEntry(newEntry);
    }

    static void SaveJournal()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        if (!string.IsNullOrEmpty(filename))
        {
            journal.SaveToFile(filename);
        }
    }

    static void LoadJournal()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        if (!string.IsNullOrEmpty(filename))
        {
            journal.LoadFromFile(filename);
        }
    }

    static void SearchJournal()
    {
        Console.Write("Enter a keyword to search: ");
        string keyword = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var results = journal.SearchEntries(keyword);
            if (results.Count == 0)
            {
                Console.WriteLine("No entries found containing the keyword: " + keyword);
            }
            else
            {
                Console.WriteLine("\n=== SEARCH RESULTS ===");
                foreach (var entry in results)
                {
                    Console.WriteLine(entry);
                    
                }   
        
            }
        }
    }
}
 