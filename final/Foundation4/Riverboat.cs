using System;

// RiverFloat.cs
// Derived: river class + distance + boats

namespace BFACampingOps
{
    // 0) Simple whitewater class enum (I–III)
    public enum RiverClass { I, II, III }
    public class RiverFloat : CampActivity
    {
        // 1) Specific fields
        public RiverClass Class { get; private set; }
        public double DistanceMiles { get; private set; }
        public int BoatsManaged { get; private set; }
    }

    // 2) Constructor
        public RiverFloat(RiverClass riverClass, double distanceMiles, int boatsManaged, string notes = "", int minutes = 0, int staff = 0, int guests = 0)
            : base("River Float", notes, minutes, staff, guests)
        {
            Class = riverClass;
            DistanceMiles = Math.Max(0, distanceMiles);
            BoatsManaged = Math.Max(0, boatsManaged);
        }


}