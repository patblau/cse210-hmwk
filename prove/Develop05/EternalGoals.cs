using Prove.Develop05;

// Requirements for GoalBase.cs
// Eternal (repeating) goal: never completes; awards base points each time
// an event is recorded. Tracks how many times it’s been recorded.
// 
// Requires the base class `Goal` (in GoalsBase.cs) that defines:
//   - protected ctor Goal(string name, string description, int points)
//   - protected helpers: Safe(string), UnSafe(string)
//   - abstract methods: RecordEvent(), ToListString(), Serialize()

public sealed class EternalGoal : Goal
{
    //Total number of times the user has recorded this goal.
    // goals never show as complete
    public int TimesRecorded { get; private set; }
    public EternalGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points)
    {
        TimesRecorded = timesRecorded < 0 ? 0 : timesRecorded;
        IsComplete = false;
    }

    /// Increment count and return base points every time it’s recorded.
    /// </summary>
    public override int RecordEvent()
    {
        TimesRecorded++;
        // Eternal goals never flip to complete; keep IsComplete false
        return Points;
    }

    /// <summary>
    /// Display like: "[ ] Read Scriptures Daily — Study the scriptures. (+100 pts each) • Logged 7 time(s)"
    /// </summary>
    public override string ToListString()
    {
        return $"[ ] {Name} — {Description} (+{Points} pts each)  • Logged {TimesRecorded} time(s)";
    }

    /// <summary>
    /// Save format:
    ///   Eternal|Name|Description|Points|TimesRecorded
    /// (pipes in text are escaped via Safe()/UnSafe())
    /// </summary>
    public override string Serialize()
    {
        return $"Eternal|{Goal.Safe(Name)}|{Goal.Safe(Description)}|{Points}|{TimesRecorded}";
    }

    /// <summary>
    /// Helper used by Goal.Deserialize(...) to rebuild an EternalGoal from tokens.
    /// Expects parts:
    ///   [0]=Eternal [1]=Name [2]=Desc [3]=Points [4]=TimesRecorded
    /// </summary>
    public static EternalGoal? Deserialize(string[] parts)
    {
        if (parts == null || parts.Length < 5) return null;
        {
            string name = Goal.UnSafe(parts[1]);
            string desc = Goal.UnSafe(parts[2]);
            int.TryParse(parts[3], out int pts);
            int.TryParse(parts[4], out int times);
            return new EternalGoal(name, desc, pts, times);
        }
    }
}