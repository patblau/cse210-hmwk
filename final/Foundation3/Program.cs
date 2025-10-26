using System;
using System.Collections.Generic;
using FamilyEvents;

// Program.cs
// Ceate events, use shared + specific features,
// show Standard, Full, and Short descriptions.

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello Foundation3 World!");
    }
    // Create examples for each derived type
    var workshop = new WorkshopEvent(
        title: "Family History Workshop: Finding Census Records",
        desc: "Hands-on session covering search tactics and citation tips.",
        start: new DateTime(2025, 11, 15, 10, 0, 0),
        location: "Community Center Room B",
        speaker: "Eleanor Price, AG®",
        capacity: 30
    );
    workshop.Register(12);

    var reunion = new ReunionEvent(
            title: "Blau Family Reunion",
            desc: "Potluck, photo scanning table, and oral history recording corner.",
            start: new DateTime(2025, 7, 20, 12, 0, 0),
            location: "Riverside Park Pavilion"
        );
    reunion.Rsvp("Pat Blau");
        reunion.Rsvp("Chris Blau");
        reunion.Rsvp("Ava Martin");

    var fair = new CommunityFairEvent(
            title: "Community Family History Fair",
            desc: "Booths for DNA basics, digitization, local archive partners, and kids crafts.",
            start: new DateTime(2025, 9, 28, 9, 0, 0),
            location: "Heritage Hall",
            weatherForecast: "Sunny, 72°F"
        );
        fair.AddBooth("DNA Q&A");
        fair.AddBooth("Scan Your Photos");
        fair.AddBooth("Youth Pedigree Crafts");
    
        // List of all events  
            var events = new List<FamilyEvent> { workshop, reunion, fair };

        // Display required formats (standard, Full, short details and discriptions)
        Console.WriteLine("=== STANDARD DETAILS ===\n");
            foreach (var e in events)
            {
                Console.WriteLine(e.GetStandardDetails());
                Console.WriteLine(new string ('-', 40));
        }

            Console.WriteLine("\n=== FULL DETAILS ===\n");
            foreach (var e in events)
        {
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine(new string('-', 40))
        }
    

            Console.WriteLine("\n=== SHORT DESCRIPTIONS ===\n");
            foreach (var e in events)
        {
            Console.WriteLine(e.GetShortDescription());
        }
    }
}
       

