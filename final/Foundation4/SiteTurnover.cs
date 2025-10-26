using System;


// SiteTurnover.cs
// Derived: clean/inspect/stock + on-time bonus

namespace BFACampingOps
{
    public class SiteTurnover : CampActivity
    {
        // 1) Specific flags
        public bool Cleaned   { get; private set; }
        public bool Inspected { get; private set; }
        public bool Stocked   { get; private set; }
        public bool OnTime    { get; private set; }
   }