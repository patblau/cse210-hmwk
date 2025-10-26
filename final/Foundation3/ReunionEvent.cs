using System;
using System.Collections.Generic;

// ReunionEvent.cs
// Derived: Reunions (RSVP tracking + guest count)

namespace FamilyEvents
{
    public class ReunionEvent : FamilyEvent
    {
        private readonly HashSet<string> _rsvps = new(StringComparer.OrdinalIgnoreCase);
        public int GuestCount => _rsvps.Count;
        public ReunionEvent(string title, string desc, DateTime start, string location)
            : base(title, desc, start, location) { }
        