using System;

// WorkshopEvent.cs
// Derived: Workshops (speaker + capacity + registrations)

namespace FamilyEvents
{
    public class WorkShopEvent : FamilyEvent
    {
        public string Speaker { get; }
        public int Capacity { get; }
        public int Registered { get; private set; }
  
        public WorkShopEvent(string title, string desc, DateTime start, string location, string speaker, int capacity)
            : base(title, desc, start, location)
        {
            Speaker = string.IsNullOrWhiteSpace(speaker) ? "Guest Speaker" : speaker.Trim();
            Capacity = Math.Max(0, capacity);
            Registered = 0;
        }

        public bool Register(int count = 1)
        {
            if (count <= 0) return false;
            if (Registered + count > Capacity) return false;
            Registered += count;
            return true;
        }
        
        protected override string GetEventType() => "Workshop";

        protected override string GetSpecificDetails()
            => $"Speaker: {Speaker}\nCapacity: {Registered}/{Capacity}";
        
    }
}
