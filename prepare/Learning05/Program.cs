using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
    }
}
/// <requierments>
/// Create base class Activities for all mindfulness activities.
/// - Provides common start/end messages and duration handling.
/// - Offers shared animations (spinner, countdown, dots).
/// - Uses Template Method pattern: Run() -> Start -> Execute() -> End.
/// </requierments>

/// // ===== Base Class (Inheritance) =====
abstract class Activity
{
    protected string _actvityName;
    protected string _discription;
    protected string _duratonSeconds;

    protected Activity(string name, string _discription)
    {
        _activityName = name;
        _discription + _discription;

    }

   

} 
}