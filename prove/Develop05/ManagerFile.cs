using System;
using System.Security.Cryptography.X509Certificates;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public int Score => _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateGoalInteractive()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1) Simple Goal");
        Console.WriteLine("2) Eternal Goal");
        Console.WriteLine("3) Checklist Goal");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completing the goal: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        Goal newGoal = null;

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
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];
            string status = goal.IsComplete ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {goal.Name} ({goal.Description}) - {goal.GetProgress()}");
        }
    }

    public void SaveInteractive()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        SaveToFile(filename);
    }

    public void LoadInteractive()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine($"SCORE|{_score}");
            foreach (Goal g in _goals)
            {
                output.WriteLine(g.Serialize());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadInteractive()
    {
        Console.Write("Enter filename to load: ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (line.StartsWith("SCORE|"))
            {
                _score = int.Parse(line.Split('|')[1]);
            }
            else
            {
                Goal goal = Goal.Deserialize(line);
                if (goal != null) _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    // Utilities for recording events and computing levels
    public static int ComputeLevel(int score)
    {
        // Simple level curve: every 500 points = 1 level
        return Math.Max(1, (score / 500) + 1);
    }
}