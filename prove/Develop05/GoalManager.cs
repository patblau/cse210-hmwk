using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private Reminder _reminder = new Reminder(19, 0, true); // default 7:00 PM reminder

    public int Score => _score;

    // Convenience properties for the UI
    public bool ReminderEnabled => _reminder.IsEnabled;
    public int ReminderHour => _reminder.Hour;
    public int ReminderMinute => _reminder.Minute;
    
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    //Menu actions
    public void CreateGoalInteractive()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1) Simple Goal");
        Console.WriteLine("2) Eternal Goal");
        Console.WriteLine("3) Checklist Goal");
        Console.Write("\nEnter choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completing the goal: ");
        int points = int.Parse(Console.ReadLine() ?? "0");
        
        Goal newGoal;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter number of times to complete for bonus: ");
                int targetCount = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine() ?? "0");
                newGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoals()
    {
        Console.Clear();
        Console.WriteLine("=== Your Goals ===\n");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ToListString()}");
            }
        }

        Console.WriteLine($"\nReminder: {(ReminderEnabled ? "ON" : "OFF")} at {ReminderHour:D2}:{ReminderMinute:D2}");
    }
public void RecordEventInteractive()
{
    if (_goals.Count == 0)
    {
        Console.WriteLine("No goals to record yet.");
        return;
    }

    ListGoals();
    Console.Write("\nTo record progress, enter goal number: ");
    int index = SafeInt(Console.ReadLine(), 0) - 1;

    if (index < 0 || index >= _goals.Count)
    {
        Console.WriteLine("Invalid selection.");
        return;
    }

    Goal goal = _goals[index];
    int before = _score;
    int earned = goal.RecordEvent();
    _score += earned;

    AnnounceMilestones(before, _score);

    if (earned > 0)
        Console.WriteLine($"\nYou earned {earned} points!");
    else
        Console.WriteLine("\nGoal already completed — no points earned.");
}

    public void SaveInteractive()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine($"SCORE|{_score}");
            output.WriteLine(_reminder.ToConfigLine());
            foreach (Goal g in _goals)
            {
                output.WriteLine(g.Serialize());
            }
        }

        Console.WriteLine("Goals were saved!");
    }
    public void LoadInteractive()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine() ?? "goals.txt";
         
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string raw in lines)
        {
            string line = raw?.Trim() ?? "";
            if (line.Length == 0) continue;

            if (line.StartsWith("SCORE|"))
            {
                _score = SafeInt(line.Split('|')[1], 0);
            }
            else if (line.StartsWith("REMINDER|"))
            {
                _reminder = Reminder.FromConfigLine(line);
            }
            else
            {
                Goal goal = Goal.Deserialize(line);
                if (goal != null) _goals.Add(goal);
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
    public void ReminderSettingsInteractive()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Reminder Settings ===");
            Console.WriteLine($"Status : {(ReminderEnabled ? "ON" : "OFF")}");
            Console.WriteLine($"Time   : {ReminderHour:D2}:{ReminderMinute:D2}");
            Console.WriteLine();
            Console.WriteLine("1) Toggle ON/OFF");
            Console.WriteLine("2) Set time (HH:MM, 24h)");
            Console.WriteLine("0) Back");
            Console.Write("\nChoose: ");
            var choice = (Console.ReadLine() ?? "").Trim();

            if (choice == "0") return;

            switch (choice)
            {
                case "1":
                    _reminder.Toggle();
                    Console.WriteLine($"Reminder is now {(ReminderEnabled ? "ON" : "OFF")}.");
                    Pause();
                    break;

                case "2":
                    Console.Write("Enter time (HH:MM, 24h): ");
                    var t = (Console.ReadLine() ?? "").Trim();
                    if (TryParseHm(t, out int h, out int m))
                    {
                        try
                        {
                            _reminder.SetTime(h, m);
                            Console.WriteLine($"Reminder time set to {h:D2}:{m:D2}.");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Hour must be 0–23 and minute 0–59.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Use AM/PM HH:MM.");
                    }
                    Pause();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    // Utilities to record events and computing rewards
    public static int ComputeLevel(int score)
    {
        // Simple level curve: every 500 points = 1 level
        return Math.Max(1, (score / 500) + 1);
    }
    private static int SafeInt(string s, int fallback)
    {
        return int.TryParse(s, out int val) ? val : fallback;
    }

    private static bool TryParseHm(string input, out int hour, out int minute)
    {
        hour = 0; minute = 0;
        var parts = input.Split(':');
        if (parts.Length != 2) return false;
        if (!int.TryParse(parts[0], out hour)) return false;
        if (!int.TryParse(parts[1], out minute)) return false;
        return hour >= 0 && hour <= 23 && minute >= 0 && minute <= 59;
    }

    private static void Pause()
    {
        Console.Write("\nPress Enter to continue...");
        Console.ReadLine();
    }
    // Call at the top of menu loop in ProgramGoals.cs to check reminders
    public void TickReminders()
    {
        _reminder.CheckAndNotify();
    }

    private void AnnounceMilestones(int previousScore, int currentScore)
    {
        if (currentScore <= previousScore) return;

        int prevHundreds = previousScore / 100;
        int currHundreds = currentScore / 100;

        for (int h = prevHundreds + 1; h <= currHundreds; h++)
        {
            int pts = h * 100;

            // Every 100 pts
            Console.WriteLine("You did it. Grab a chocolate Dove Square.");
            Console.WriteLine("Savings reminder: Add $10 to savings.");

            // Every 500 pts (i.e., when h % 5 == 0)
            if (h % 5 == 0)
                Console.WriteLine("Way to go. Time for some cookies.");

            // Every 1000 pts
            if (h % 10 == 0)
                Console.WriteLine("You did it. Have some ice cream.");

            // Every 5000 pts
            if (h % 50 == 0)
                Console.WriteLine("Way to hang in there. Have a slice of cake/pie. You deserve it.");

            // At 9000 pts exactly
            if (pts == 9000)
                Console.WriteLine("9000 points achieved. Start planning your get away.");

            // Every 10,000 pts
            if (h % 100 == 0)
                Console.WriteLine("Time to have some fun. Enjoy your week end. You earned it.");
        }

        Console.WriteLine($"Total Dove chocolates so far: {currentScore / 100}");
        Console.WriteLine($"Current savings: ${(currentScore / 100) * 10}");
    }
}
public class Reminder
{
    public int Hour { get; private set; }
    public int Minute { get; private set; }
    public bool IsEnabled { get; private set; }

    // Track last notification to avoid spamming within the same minute
    private int _lastNotifiedDayOfYear = -1;
    private int _lastNotifiedMinute = -1;

    public Reminder(int hour, int minute, bool enabled)
    {
        SetTime(hour, minute);
        IsEnabled = enabled;
    }

    public void Toggle() => IsEnabled = !IsEnabled;

    public void SetTime(int hour, int minute)
    {
        if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
            throw new ArgumentOutOfRangeException(nameof(hour), "Hour must be 0–23 and minute 0–59.");
        Hour = hour;
        Minute = minute;
    }

    public string ToConfigLine()
    {
        // Format: REMINDER|{hour}|{minute}|{enabledFlag}
        return $"REMINDER|{Hour}|{Minute}|{(IsEnabled ? 1 : 0)}";
    }

    public static Reminder FromConfigLine(string line)
    {
        // Expect: REMINDER|H|M|EN where EN is 1/0 or true/false
        if (string.IsNullOrWhiteSpace(line)) return new Reminder(19, 0, true);

        var parts = line.Split('|');
        if (parts.Length < 4) return new Reminder(19, 0, true);

        int h = 19, m = 0;
        bool en = true;

        int.TryParse(parts[1], out h);
        int.TryParse(parts[2], out m);
        en = parts[3] == "1" || parts[3].ToLowerInvariant() == "true";

        return new Reminder(h, m, en);
    }

    public void CheckAndNotify()
    {
        if (!IsEnabled) return;

        var now = DateTime.Now;
        if (now.Hour == Hour && now.Minute == Minute)
        {
            // Only notify once per minute
            if (_lastNotifiedDayOfYear == now.DayOfYear && _lastNotifiedMinute == now.Minute) return;
            _lastNotifiedDayOfYear = now.DayOfYear;
            _lastNotifiedMinute = now.Minute;

            Console.WriteLine($"\n=== Reminder ===\nIt's {Hour:D2}:{Minute:D2} — time to review your goals!\n================\n");
        }
    }
}
