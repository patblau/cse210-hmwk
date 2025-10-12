using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you achieved something you once thought was impossible.",
        "Think of a time when you forgave someone who hurt you.",
        "Think of a time when you made a positive difference in someone’s life.",
        "Think of a time when you faced a fear and overcame it.",
        "Think of a time when you chose to be honest even when it was hard.",
        "Think of a time when you worked hard toward a goal and succeeded."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
        "This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void RunCore()
    {
        var rng = new Random();

        // Then prompt
        string prompt = _prompts[rng.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($">>> {prompt}");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue...");
        Console.ReadLine();

        // Prepare 
        Console.WriteLine("\nGet ready to begin your reflection...");
        ShowCountdown(5);
        Console.WriteLine();


        Console.WriteLine("Now ponder the following questions related to this experience.\n");

        // Set overall timer
        var end = DateTime.Now.AddSeconds(DurationSeconds);
        Console.WriteLine($"You will reflect for {DurationSeconds} seconds.\n");

        // Loop while time remains
        while (DateTime.Now < end)
        {
            // Show remaining time
            TimeSpan remaining = end - DateTime.Now;
            Console.WriteLine($"⏳ Time remaining: {remaining.Minutes:D2}:{remaining.Seconds:D2}");

            // Ask a random question
            string question = _questions[rng.Next(_questions.Count)];
            Console.WriteLine($"\n• {question}");

            // Spinner delay
            ShowSpinner(5);
            Console.WriteLine();
        }

        Console.WriteLine("\nYour reflection session is complete. Take a moment to internalize what you discovered.");
        ShowSpinner(3);
    }
}