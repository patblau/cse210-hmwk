using System;

namespace BFAdventureVideos
{

    /// Videos about campground facilities.
    /// Each FacilityVideo has a FacilityType in addition to the Theme.

    public class FacilityVideo : ThemedVideo
    {
        // Public Property for Facility Videos
        public string FacilityType { get; }

        // Constructor 
        public FacilityVideo(string title, string author, int length, string facilityType)
            : base(title, author, length, "Facility")
        {
            FacilityType = string.IsNullOrWhiteSpace(facilityType)
                ? "General Facility"
                : facilityType.Trim();
        }
    }
}