using System;

// ReservationProcessing.cs
// Derived: bookings handled + accuracy bonus

namespace BFACampingOps
{
    public class ReservationProcessing : CampActivity
    {
        // 1) Specific fields
        public int BookingsHandled { get; private set; }
        public int AccuracyPercent { get; private set; } // 0–100
    }
}