using System;
using System.Collections.Generic;
using FamilyEvents;

class Program
{
    static void Main()
    {
        //Create a few sample activities (using derived types)

        // Display summaries and compute total points (same calls, different behavior)
        Console.WriteLine("=== BFA Camping — Operations & Activities Tracker ===\n");
        int total = 0;
        foreach (var act in activities)
        {
            Console.WriteLine(act.Summary());   // overridden per subclass
            total += act.PointsEarned();        // overridden per subclass
        }
        Console.WriteLine($"\nTotal Points (shift): {total}");
    }
}