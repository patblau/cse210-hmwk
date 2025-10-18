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

   