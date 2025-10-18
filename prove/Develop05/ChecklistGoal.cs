using Prove.Develop05;

//Checklist goal: earn base points each time; when CurrentCount reaches
// TargetCount, award a one-time BonusPoints and mark complete.
// 
// Requires base class Goal (GoalsBase.cs) with:
//   - protected Goal(string name, string description, int points)
//   - protected helpers: Safe(string), UnSafe(string), BoolStr(bool), ParseBool(string)
//   - abstract methods: RecordEvent(), ToListString(), Serialize()

public sealed class ChecklistGoal : Goal
{
    public int CurrentCount { get; private set; }
    public int TargetCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
        TargetCount = targetCount < 1 ? 1 : targetCount;
        BonusPoints = bonusPoints < 0 ? 0 : bonusPoints;
        CurrentCount = currentCount < 0 ? 0 : currentCount;
        IsComplete = CurrentCount >= TargetCount;
    }