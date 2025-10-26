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
        public WorkshopEvent(string title, string desc, DateTime start, string location, string speaker, int capacity)
            : base(title, desc, start, location)
        {
            Speaker = string.IsNullOrWhiteSpace(speaker) ? "Guest Speaker" : speaker.Trim();
            Capacity = Math.Max(0, capacity);
            Registered = 0;
        }
        
        

