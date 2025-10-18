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

    
}
    