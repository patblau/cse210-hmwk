using Prove.Develop05;

//Checklist goal: earn base points each time; when CurrentCount reaches
// TargetCount, award a one-time BonusPoints and mark complete.
// 
// Requires base class Goal (GoalsBase.cs) with:
//   - protected Goal(string name, string description, int points)
//   - protected helpers: Safe(string), UnSafe(string), BoolStr(bool), ParseBool(string)
//   - abstract methods: RecordEvent(), ToListString(), Serialize()