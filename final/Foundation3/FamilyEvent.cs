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

}