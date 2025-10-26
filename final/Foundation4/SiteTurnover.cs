using System;


// SiteTurnover.cs
// Derived: clean/inspect/stock + on-time bonus

namespace BFACampingOps
{
    public class SiteTurnover : CampActivity
    {
        // 1) Specific flags
        public bool Cleaned { get; private set; }
        public bool Inspected { get; private set; }
        public bool Stocked { get; private set; }
        public bool OnTime { get; private set; }
    }
   
   // Constructor
        public SiteTurnover(string notes = "", int minutes = 0, int staff = 0, int guests = 0,
                            bool cleaned = false, bool inspected = false, bool stocked = false, bool onTime = false)
            : base("Site Turnover", notes, minutes, staff, guests)
        {
            Cleaned = cleaned; Inspected = inspected; Stocked = stocked; OnTime = onTime;
        }

        // 3) Mutators
        public void MarkCleaned(bool v = true)  => Cleaned = v;
        public void MarkInspected(bool v = true)=> Inspected = v;
        public void MarkStocked(bool v = true)  => Stocked = v;
        public void MarkOnTime(bool v = true)   => OnTime = v;
