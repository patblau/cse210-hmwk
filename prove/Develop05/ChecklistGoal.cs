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

    }
    // Increment count and return base points; if target reached, award bonus and mark complete.
    public ChecklistGoal(string name, string description, int points,
                         int targetCount, int bonusPoints, int currentCount = 0)
        : base(name, description, points)
    {
    TargetCount = Math.Max(1, targetCount);   // must complete at least once
    BonusPoints = Math.Max(0, bonusPoints);
    CurrentCount = Math.Max(0, currentCount);
    IsComplete = CurrentCount >= TargetCount;

    // Adds one completion. Awards base Points each time; when reaching TargetCount,
    // also awards BonusPoints and marks complete. If already complete, returns 0.
    public override int RecordEvent()
    {
        if (IsComplete) return 0;

        CurrentCount++;
        int earned = Points;

        if (CurrentCount >= TargetCount)
        {
            IsComplete = true;
            earned += BonusPoints;
        }

        return earned;
    }

// Example: "[ ] Ministering Visits — Visit 3 times (+100 pts, bonus 300 on 3)  • Completed 1/3"
public override string ToListString()
{
    string mark = IsComplete ? "[X]" : "[ ]";
    return $"{mark} {Name} — {Description} (+{Points} pts, bonus {BonusPoints} on {TargetCount})  • Completed {CurrentCount}/{TargetCount}";
}
    
    // Save format: Checklist|Name|Description|Points|CurrentCount|TargetCount|BonusPoints|IsComplete
    public override string Serialize()
    {
        return $"Checklist|{Safe(Name)}|{Safe(Description)}|{Points}|{CurrentCount}|{TargetCount}|{BonusPoints}|{BoolStr(IsComplete)}";
    }