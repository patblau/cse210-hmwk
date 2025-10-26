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


}