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
        
