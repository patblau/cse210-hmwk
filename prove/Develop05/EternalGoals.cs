using System;

// Requirements for GoalBase.cs
// Eternal (repeating) goal: never completes; awards base points each time
// an event is recorded. Tracks how many times it’s been recorded.
// 
// Requires the base class `Goal` (in GoalsBase.cs) that defines:
//   - protected ctor Goal(string name, string description, int points)
//   - protected helpers: Safe(string), UnSafe(string)
//   - abstract methods: RecordEvent(), ToListString(), Serialize()
