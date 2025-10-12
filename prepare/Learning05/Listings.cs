using System;
using System.Collections.Generic;


public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        // --- Extra prompts to make it more engaging ---
        "What are some goals you have accomplished recently?",
        "What are things in your life that bring you peace?",
        "What are moments that made you smile this week?",
        "What are talents or skills you are grateful for?",
        "What are things you love about nature?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list " +
        "as many things as you can in a certain area.")
    { }

    protected override void RunCore()
    {
        var rng = new Random();

        // Choose a random prompt
        string prompt = _prompts[rng.Next(_prompts.Count)];
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($">>> {prompt}");
        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        var items = new List<string>();
        var end = DateTime.Now.AddSeconds(DurationSeconds);

        // Collect user input until time expires
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string? entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items. Well done!");
        ShowSpinner(3);
    }
}