using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("""Hello Learning05 World!""");
    }
}
/// <requierments>
/// Create base class Activities for all mindfulness activities.
/// - Provides common start/end messages and duration handling.
/// - Offers shared animations (spinner, countdown, dots).
/// - Uses Template Method pattern: Run() -> Start -> Execute() -> End.
/// </requierments>

// ===== Base Class (Inheritance) =====
abstract class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _durationSeconds;

    protected Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }

    // Template Method
    public void Run()
    {
        Console.Clear();
        StartActivity();
        Execute();     // implemented by derived classes
        EndActivity();
    }

    protected abstract void Execute();

    // ---- Shared start/end flow ----
    protected virtual void StartActivity()
    {
        Console.WriteLine($"""--- {_activityName} ---""");
        Console.WriteLine(_description);
        Console.WriteLine();

        _durationSeconds = AskDuration();

        Console.Write("""Get ready """);
        AnimatePause(3);
        Console.WriteLine();
    }

    protected virtual void EndActivity()
    {
        Console.Write("\nGreat job! ");
        AnimatePause(2);
        Console.WriteLine($"\nYou completed the {_activityName} for {_durationSeconds} seconds.");
        PauseWithDots(3);
    }

    private int AskDuration()
    {
        while (true)
        {
            Console.Write("""Enter duration in seconds (e.g., 30): """);
            string? s = Console.ReadLine();
            if (int.TryParse(s, out int sec) && sec > 0) return sec;
            Console.WriteLine("Please enter a positive whole number.\n");
        }
    }

    // ---- Shared animations ----
    protected void Spinner(int seconds)
    {
        char[] frames = { '|', '/', '-', '\\' };
        var sw = Stopwatch.StartNew();
        int i = 0;
        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write($"\r{frames[i++ % frames.Length]}");
            Thread.Sleep(120);
        }
        Console.Write("\r \r");
    }

    protected void Countdown(int seconds, string prefix = "")
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"\r{prefix}{i} ");
            Thread.Sleep(1000);
        }
        Console.Write("\r    \r");
    }

    protected void PauseWithDots(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(""".""");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // ---- Hooks (customizable per activity) ----
    protected virtual void AnimatePause(int seconds) => Spinner(seconds);
    protected virtual void AnimateCountdown(int seconds, string prefix = "") => Countdown(seconds, prefix);

    // Optional progress helper
    protected void ShowProgress(TimeSpan elapsed)
    {
        if (_durationSeconds <= 0) return;
        int pct = Math.Min(100, (int)(elapsed.TotalSeconds / _durationSeconds * 100.0));
        Console.WriteLine($"""Progress: {pct}%""");
    }
}

// ===== Derived: Breathing =====
class BreathingActivity : Activity
{
    private readonly int _inhale = 4;
    private readonly int _exhale = 6;

    public BreathingActivity()
        : base("""Breathing Activity""",
               """This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.""") { }

    protected override void Execute()
    {
        var sw = Stopwatch.StartNew();
        while (sw.Elapsed.TotalSeconds < _durationSeconds)
        {
            Console.WriteLine("""Breathe in...""");
            AnimateCountdown(_inhale, """Inhale: """);
            if (sw.Elapsed.TotalSeconds >= _durationSeconds) break;

            Console.WriteLine("""Breathe out...""");
            AnimateCountdown(_exhale, """Exhale: """);

            ShowProgress(sw.Elapsed);
        }
    }

    // Give breathing a distinct countdown feel (big numbers)
    protected override void AnimateCountdown(int seconds, string prefix = "")
        => Countdown(seconds, prefix);
}

// ===== Derived: Reflection =====
class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        """Think of a time when you stood up for someone else.""",
        """Think of a time when you did something really difficult.""",
        """Think of a time when you helped someone in need.""",
        """Think of a time when you did something truly selfless."""
    };

    private readonly List<string> _questions = new()
    {
        """Why was this experience meaningful to you?""",
        """Have you ever done anything like this before?""",
        """How did you get started?""",
        """How did you feel when it was complete?""",
        """What made this time different than other times when you were not as successful?""",
        """What is your favorite thing about this experience?""",
        """What could you learn from this experience that applies to other situations?""",
        """What did you learn about yourself through this experience?""",
        """How can you keep this experience in mind in the future?"""
    };

    private readonly Random _rng = new();

    public ReflectionActivity()
        : base("""Reflection Activity""",
               """This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.""") { }

    protected override void Execute()
    {
        string prompt = _prompts[_rng.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n> {prompt}");
        Console.Write("\nWhen you have a specific memory in mind, we'll begin ");
        AnimatePause(4);
        Console.WriteLine();

        var sw = Stopwatch.StartNew();
        while (sw.Elapsed.TotalSeconds < _durationSeconds)
        {
            string q = _questions[_rng.Next(_questions.Count)];
            Console.WriteLine($"\nReflect: {q}");
            AnimatePause(7);        // quiet thinking time
            ShowProgress(sw.Elapsed);
        }
    }

    protected override void AnimatePause(int seconds) => Spinner(seconds); // smooth spinner
}

// ===== Derived: Listing =====
class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        """Who are people that you appreciate?""",
        """What are personal strengths of yours?""",
        """Who are people that you have helped this week?""",
        """When have you felt the Holy Ghost this month?""",
        """Who are some of your personal heroes?"""
    };
    private readonly Random _rng = new();

    public ListingActivity()
        : base("""Listing Activity""",
               """This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.""") { }

    protected override void Execute()
    {
        string prompt = _prompts[_rng.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt:\n> {prompt}");
        Console.Write("\nYou’ll have a moment to think ");
        AnimatePause(3);

        Console.WriteLine("\nStart listing. Press Enter after each item.");
        var items = new List<string>();
        var sw = Stopwatch.StartNew();

        while (sw.Elapsed.TotalSeconds < _durationSeconds)
        {
            Console.Write("""> """);
            if (_durationSeconds - sw.Elapsed.TotalSeconds < 0.75) break; // graceful end
            string? line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line)) items.Add(line.Trim());
            ShowProgress(sw.Elapsed);
        }

        Console.WriteLine($"\nYou listed {items.Count} item(s).");
        PauseWithDots(2);
    }

    // Simple progress bar animation for this activity
    protected override void AnimatePause(int seconds)
    {
        int totalTicks = seconds * 10;
        for (int i = 0; i <= totalTicks; i++)
        {
            double pct = i / (double)totalTicks;
            int bars = (int)(pct * 20);
            Console.Write($"\r[{new string('#', bars)}{new string('.', 20 - bars)}] {(int)(pct * 100)}%");
            Thread.Sleep(100);
        }
        Console.Write("\r" + new string(' ', 40) + "\r");
    }
}

// ===== Program / Menu =====
class Program
{
    static void Main(string[] args)
    {
        var activities = new Dictionary<string, Activity>
        {
            { """1""", new BreathingActivity() },
            { """2""", new ReflectionActivity() },
            { """3""", new ListingActivity() }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("""MINDFULNESS APP""");
            Console.WriteLine("""----------------""");
            Console.WriteLine("""1) Breathing Activity""");
            Console.WriteLine("""2) Reflection Activity""");
            Console.WriteLine("""3) Listing Activity""");
            Console.WriteLine("""Q) Quit""");
            Console.Write("\nChoose an option: ");

            string? choice = Console.ReadLine()?.Trim().ToUpperInvariant();

            if (choice == """Q""")
            {
                Console.WriteLine("\nThanks for practicing today. See you next time!");
                return;
            }

            if (choice != null && activities.TryGetValue(choice, out var activity))
            {
                activity.Run();
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("""Invalid selection. Press Enter to try again...""");
                Console.ReadLine();
            }
        }
    }
}
