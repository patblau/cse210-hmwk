using System;
using System.Collections.Generic;
using BFACampingOps;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation4 World!");
    }

    // Create a few sample activities (using derived types)
    var a1 = new ReservationProcessing(minutes: 45, staff: 1, bookingsHandled: 12, accuracyPercent: 97);
    var a2 = new SiteTurnover(minutes: 50, staff: 2, cleaned: true, inspected: true, stocked: true, onTime: true);
    var a3 = new GearCheckout(EquipmentType.Kayak, minutes: 30, staff: 1, guests: 18, volume: 12, damage: 0);
    var a4 = new GuidedHike(HikeDifficulty.Moderate, miles: 3.5, minutes: 120, staff: 2, guests: 10);
    var a5 = new RiverFloat(RiverClass.II, distanceMiles: 5.2, boatsManaged: 6, minutes: 150, staff: 3, guests: 18);

    // Polymorphic container — treat them all as CampActivity
    var activities = new List<CampActivity> { a1, a2, a3, a4, a5 };
        
    //Distplay 
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


}

