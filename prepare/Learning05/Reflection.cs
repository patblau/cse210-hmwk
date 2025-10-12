using System;
using System.Collections.Generic;

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
        "Think of a time when you made a positive difference in someones life.",
        "Think of a time when you overcame your fears.",
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
        "How can you keep this experience in mind in the future?",
        "What personal strengths did you use to face this situation?",
        "What fears or doubts did you have to overcome?",
        "Who influenced or supported you during this experience?",
        "How can you use this lesson to help someone else?",
        "What blessings came from this challenge that you didn’t expect?",
        "How has your perspective changed since this experience?"
        };

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
        "This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void RunCore()
    {
        var rng = new Random();

        // 1) Show a random prompt
        string prompt = _prompts[rng.Next(_prompts.Count)];
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($">>> {prompt}");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue...");
        Console.ReadLine();

        Console.WriteLine("Now ponder the following questions related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine("\n");

        // 2) Ask random questions with a spinner pause until duration is up
        var end = DateTime.Now.AddSeconds(DurationSeconds);
        while (DateTime.Now < end)
        {
            string question = _questions[rng.Next(_questions.Count)];
            Console.WriteLine($"• {question}");

            // Pause ~6 seconds (or remaining time) with spinner
            int pause = Math.Min(6, (int)Math.Ceiling((end - DateTime.Now).TotalSeconds));
            if (pause > 0) ShowSpinner(pause);
            Console.WriteLine();
        }
    }
}

