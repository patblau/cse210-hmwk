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
        public bool Rsvp(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return _rsvps.Add(name.Trim());

            public IReadOnlyCollection<string> GetRsvps() => _rsvps;
        }