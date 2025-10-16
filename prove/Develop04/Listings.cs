// Reflection.cs
using System;
using System.Collections.Generic;
using System.Threading;

public class Reflection : Activity
{
    // "Think of a time..." prompts (10 total)
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

    // Reflection questions to rotate during the session
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

    public Reflection() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
        "This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void RunCore()
    {
        var rng = new Random();

        // 1) Prepare first
        Console.WriteLine("\nGet ready to begin your reflection...");
        ShowCountdown(5);
        Console.WriteLine();

        // 2) Then show the prompt
        string prompt = _prompts[rng.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($">>> {prompt}");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue...");
        Console.ReadLine();
        Console.WriteLine("Now ponder the following questions related to this experience.\n");

        // ===== Live countdown status line (like Listings.cs) =====
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(DurationSeconds);
        int statusTop = Console.CursorTop;

        Console.WriteLine(); // status line placeholder
        Console.WriteLine("Reflect on the question shown below. (New question every ~6 seconds)");
        Console.WriteLine(); // spacer before the question text

        int lastSecondDrawn = -1;
        int lastQuestionSecond = -10; // ensure we draw a question immediately
        string currentQuestion = string.Empty;

        while (DateTime.Now < end)
        {
            // 1) Update timer/progress once per second
            int remaining = Math.Max(0, (int)Math.Ceiling((end - DateTime.Now).TotalSeconds));
            if (remaining != lastSecondDrawn)
            {
                DrawStatusTimer(statusTop, DurationSeconds, remaining);
                lastSecondDrawn = remaining;
            }

            // 2) Rotate questions approximately every 6 seconds
            int elapsed = (int)(DateTime.Now - start).TotalSeconds;
            if (elapsed - lastQuestionSecond >= 6)
            {
                currentQuestion = _questions[rng.Next(_questions.Count)];
                WriteQuestion(statusTop + 2, currentQuestion); // statusTop + 0 = status, +1 = instruction, +2 = question line
                lastQuestionSecond = elapsed;
            }

            // small sleep to keep UI responsive without hogging CPU
            Thread.Sleep(20);
        }

        // Clear status and close out
        ClearLine(statusTop);
        Console.SetCursorPosition(0, statusTop);
        Console.WriteLine("⏰ Time’s up!");

        Console.WriteLine("\nYour reflection session is complete. Take a moment to internalize what you discovered.");
        ShowSpinner(3);
    }

    // ===== Helpers (same feel as Listings.cs timer) =====

    // Single-line countdown + progress bar on reserved status line
    private void DrawStatusTimer(int statusTop, int totalSeconds, int remainingSeconds)
    {
        int elapsed = Math.Max(0, totalSeconds - remainingSeconds);
        const int BAR_WIDTH = 30;
        double pct = totalSeconds <= 0 ? 1.0 : (double)elapsed / totalSeconds;
        int filled = Math.Min(BAR_WIDTH, (int)Math.Round(pct * BAR_WIDTH));

        string bar = "[" + new string('█', filled) + new string('─', BAR_WIDTH - filled) + "]";
        string clock = $"{remainingSeconds / 60:D2}:{remainingSeconds % 60:D2}";

        // Save current cursor
        int curLeft = Console.CursorLeft;
        int curTop = Console.CursorTop;

        // Draw on reserved line
        Console.SetCursorPosition(0, statusTop);
        ClearLine(statusTop);
        Console.SetCursorPosition(0, statusTop);
        Console.Write($"⏳ {clock}  {bar}  (reflecting)");

        // Restore cursor
        Console.SetCursorPosition(curLeft, curTop);
    }

    // Writes/overwrites the question on a fixed line
    private void WriteQuestion(int row, string question)
    {
        int curLeft = Console.CursorLeft;
        int curTop = Console.CursorTop;

        Console.SetCursorPosition(0, row);
        ClearLine(row);
        Console.SetCursorPosition(0, row);
        Console.Write("• " + question);

        Console.SetCursorPosition(curLeft, curTop);
    }

    private void ClearLine(int row)
    {
        int curLeft = Console.CursorLeft;
        int curTop = Console.CursorTop;
        Console.SetCursorPosition(0, row);
        Console.Write(new string(' ', Console.BufferWidth - 1));
        Console.SetCursorPosition(curLeft, curTop);
    }
}
