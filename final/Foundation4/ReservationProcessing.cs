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

        // 2) Constructor
        public ReservationProcessing(string notes = "", int minutes = 0, int staff = 0, int guests = 0,
                                     int bookingsHandled = 0, int accuracyPercent = 100)
            : base("Reservation Processing", notes, minutes, staff, guests)
        {
            BookingsHandled = Math.Max(0, bookingsHandled);
            AccuracyPercent = Math.Clamp(accuracyPercent, 0, 100);
        }

        // 3) Behavior (encapsulated updates)
        public void AddBookings(int count)   => BookingsHandled += Math.max(0, count);
        public void SetAccuracy(int percent) => AccuracyPercent = Math.Clamp(percent, 0, 100);

        // 4) Polymorphic scoring + summary
        public override int PointsEarned()
        {
            // Outline: time component + per-booking score + accuracy bonus tiers
            // return computed total;
            return base.PointsEarned(); // placeholder
        }

        // Outline: include bookings + accuracy in the string
        public override string Summary()
        {  
            return $"{Name} — [outline summary here] | Points: {PointsEarned()}";
        }

        // Polymorphic scoring + summary
        public override int PointsEarned()
        {
            // Outline: time component + per-booking score + accuracy bonus tiers
            // return computed total;
            return base.PointsEarned(); // placeholder
        }
    }
}