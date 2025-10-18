//Requirements for Goal base class:
//  - Abstract base class for all goal types 
//  -  Shared state: Name, Description, Points, IsComplete
//  -  Polymorphic contract: RecordEvent(), ToListString(), Serialize()
//  -  Static factory: Deserialize(string line) -> Goal

public abstract class Goal
{
    // Shared state (encapsulated) 
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    // Protected ctor enforces basic validation for all derived goals.
    protected Goal(string name, string description, int points)
    {
        Name = name ?? string.Empty;
        Description = description ?? string.Empty;
        Points = points < 0 ? 0 : points;
        IsComplete = false;
    }

    // Polymorphic contract: Apply progress to this goal and return points earned.
    public abstract int RecordEvent();

    // One-line display for lists. Must include [ ]/[X] and any progress info.
    public abstract string ToListString();

    // Return a single-line text used by Save/Load.
    public abstract string Serialize();

    // Helpers for safe save/load: Escape pipe to avoid breaking the save format.
    protected static string Safe(string s) => (s ?? string.Empty).Replace("|", "¦");

    // Unescape pipe when loading.
    protected static string UnSafe(string s) => (s ?? string.Empty).Replace("¦", "|");

    // Compact bool format (1/0) to keep files readable.
    protected static string BoolStr(bool b) => b ? "1" : "0";

    // Parse "1"/"0" or "true"/"false". Anything else -> false.
    protected static bool ParseBool(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return false;
        s = s.Trim();
        return s == "1" || s.Equals("true", StringComparison.OrdinalIgnoreCase);
    }

    // Factory: rebuild a Goal from a serialized line.
    // Create a concrete Goal from a serialized line.
    // Expected formats:
    //   Simple|Name|Desc|Points|IsComplete
    //   Eternal|Name|Desc|Points|TimesRecorded
    //   Checklist|Name|Desc|Points|Target|Current|Bonus|IsComplete
    // Returns null if the line is invalid or type is unknown.
    
    public static Goal Deserialize(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return null;

        var parts = line.Split('|');
        if (parts.Length == 0) return null;

        string type = parts[0];

        switch (type)
        {
            case "Simple":
                return SimpleGoal.Deserialize(parts);

            case "Eternal":
                return EternalGoal.Deserialize(parts);

            case "Checklist":
                return ChecklistGoal.Deserialize(parts);

            // If you later add ServiceGoal, add:
            // case "Service": return ServiceGoal.Deserialize(parts);

            default:
                return null;
        }
    }
}
    