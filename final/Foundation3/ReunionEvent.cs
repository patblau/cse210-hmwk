using System;
using System.Collections.Generic;

// ReunionEvent.cs
// Derived: Reunions (RSVP tracking + guest count)

namespace FamilyEvents
{
    public class ReunionEvent : FamilyEvent
    {
        private readonly HashSet<string> _rsvps = new(StringComparer.OrdinalIgnoreCase);