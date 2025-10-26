using System;

// GuidedHike.cs
// Derived: difficulty + miles + guest impact

namespace BFACampingOps
{
    //Enum for trail difficulty
    public enum HikeDifficulty { Easy, Moderate, Hard }

    public class GuidedHike : CampActivity
    {
        // Specific fields
        public HikeDifficulty Difficulty { get; private set; }
        public double Miles { get; private set; }

        // Constructor
        public GuidedHike(HikeDifficulty difficulty, double miles, string notes = "", int minutes = 0, int staff = 0, int guests = 0)

            : base("Guided Hike", notes, minutes, staff, guests)
        {
            Difficulty = difficulty;
            Miles = Math.Max(0, miles);
        }

        // Polymorphic scoring + summary
        public override int PointsEarned()
        {
            // Outline: time + guests + miles + difficulty bonus
            return base.PointsEarned(); // placeholder
        }
         public override string Summary()
        {
            // Outline: show difficulty, miles, guests, minutes, points
            return $"{Name} — [Diff/Miles/Guests] | Points: {PointsEarned()}";
        }
    }
}


