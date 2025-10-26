using System;

// ReservationProcessing.cs
// Derived: bookings handled + accuracy bonus

namespace BFACampingOps
{
    public class ReservationProcessing : CampActivity
    {
        // Specific fields
        public int BookingsHandled { get; private set; }
        public int AccuracyPercent { get; private set; } // 0–100
    }

        // Constructor
            public ReservationProcessing(string notes = "", int minutes = 0, int staff = 0, int guests = 0,
            int bookingsHandled = 0, int accuracyPercent = 100)
                : base("Reservation Processing", notes, minutes, staff, guests)
            {
                BookingsHandled = Math.Max(0, bookingsHandled);
                AccuracyPercent = Math.Clamp(accuracyPercent, 0, 100);
            }
    
    }       // Behavior (encapsulated updates)
            public void AddBookings(int count)   => BookingsHandled += Math.max(0, count);
            public void SetAccuracy(int percent) => AccuracyPercent = Math.Clamp(percent, 0, 100);