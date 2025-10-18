using System;

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

   
}