using System;

// FamilyEvent.cs
// Base class: shared attributes + formatted descriptions

namespace FamilyEvents
{
    /// Shared event data: title, description, date/time, location.
    /// Derived types add their own specifics (workshop, reunion, fair).
   
    public abstract class FamilyEvent
    {
        // Shared state (encapsulated via getters only)
        public string Title { get; }
        public string Description { get; }
        public DateTime Start { get; }      // date + time
        public string Location { get; }

        protected FamilyEvent(string title, string description, DateTime start, string location)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Untitled Event" : title.Trim();
            Description = string.IsNullOrWhiteSpace(description) ? "TBA" : description.Trim();
            Start = start;
            Location = string.IsNullOrWhiteSpace(location) ? "TBA" : location.Trim();
        }

        // --- Formatting helpers used by all events ---
        public virtual string GetStandardDetails()
            => $"{Title}\nWhen: {Start:dddd, MMM d, yyyy h:mm tt}\nWhere: {Location}";

        public virtual string GetFullDetails()
            => $"{GetStandardDetails()}\nDetails: {Description}\n{GetSpecificDetails()}";

        public virtual string GetShortDescription()
            => $"{GetEventType()}: {Title} — {Start:MMM d}";
    
    
    }
}