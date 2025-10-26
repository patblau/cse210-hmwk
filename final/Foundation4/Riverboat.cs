using System;

// RiverFloat.cs
// Derived: river class + distance + boats

namespace BFACampingOps
{
    // Simple whitewater class enum (I–III)
    public enum RiverClass { I, II, III }

    public class RiverFloat : CampActivity
    {
        // 1) Specific fields
        public RiverClass Class { get; private set; }
        public double DistanceMiles { get; private set; }
        public int BoatsManaged { get; private set; }

        public RiverFloat(RiverClass riverClass, double distanceMiles, int boatsManaged, string notes = "", int minutes = 0, int staff = 0, int guests = 0)

            : base("River Float", notes, minutes, staff, guests)
        {
            Class = riverClass;
            DistanceMiles = Math.Max(0, distanceMiles);
            BoatsManaged = Math.Max(0, boatsManaged);
        }


        public double DistanceMiles { get; private set; }
        public int BoatsManaged { get; private set; }


        // Constructor
        public RiverFloat(RiverClass riverClass, double distanceMiles, int boatsManaged, string notes = "", int minutes = 0, int staff = 0, int guests = 0)
            : base("River Float", notes, minutes, staff, guests)
        {
            SetClass(riverClass);
            DistanceMiles = Math.Max(0, distanceMiles);
            BoatsManaged = Math.Max(0, boatsManaged);
        }

        // Polymorphic scoring + summary
        // Outline: time + guests + distance + boat count + class bonus
        public override int PointsEarned()
        {
            return base.PointsEarned(); // placeholder
        }

        public override string Summary()
        {
            // Outline: show class, distance, boats, guests, minutes, points
            return $"{Name} — [Class/Dist/Boats] | Points: {PointsEarned()}";
        }
    }
}


    












