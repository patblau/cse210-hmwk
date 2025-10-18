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

    /