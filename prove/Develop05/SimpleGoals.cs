using System;

/// One-and-done goal. Awards points once, then remains completed.
/// Define base class in GoalsBase.cs as:
///   - protected ctor Goal(string name, string description, int points)
///   - protected helpers: Safe(string), UnSafe(string), BoolStr(bool), ParseBool(string)
///   - abstract methods: RecordEvent(), ToListString(), Serialize()

public sealed class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        IsComplete = isComplete;
    }
    // Mark complete on first record; award base points once.If already complete, no points are awarded.

    public override int RecordEvent()
    {
        if (IsComplete) return 0;
        IsComplete = true;
        return Points;
    }

    // Display: "[X] Run a Marathon — Finish a 26.2-mile race. (+1000 pts)"
    public override string ToListString()
    {
        string mark = IsComplete ? "[X]" : "[ ]";
        return $"{mark} {Name} — {Description} (+{Points} pts)";
    }

    // Save format:
    //  - Simple|Name|Description|Points|IsComplete
    //  - (pipes in text are escaped by Safe()/UnSafe() in the base class)
    public override string Serialize()
    {
        return $"Simple|{Goal.Safe(Name)}|{Goal.Safe(Description)}|{Points}|{Goal.BoolStr(IsComplete)}";
    }

    // Helper used by Goal.Deserialize to rebuild a SimpleGoal from tokens.
    // Expects parts:[0]=Simple [1]=Name [2]=Desc [3]=Points [4]=IsComplete
    public static SimpleGoal? Deserialize(string[] parts)
    {
        if (parts != null && parts.Length >= 5)
        {
            string name = Goal.UnSafe(parts[1]);
            string desc = Goal.UnSafe(parts[2]);
            int.TryParse(parts[3], out int pts);
            bool isComplete = parts[4] == "1" || parts[4].Equals("true", StringComparison.OrdinalIgnoreCase);
            return new SimpleGoal(name, desc, pts, isComplete);
        }

        return null;
    }
}


   
    