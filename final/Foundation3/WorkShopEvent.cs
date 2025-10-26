using System;

// WorkshopEvent.cs
// Derived: Workshops (speaker + capacity + registrations)

namespace FamilyEvents
{
    public class WorkshopEvent : FamilyEvent
    {
        public string Speaker { get; }
        public int Capacity { get; }
        public int Registered { get; private set; }
    }
}

