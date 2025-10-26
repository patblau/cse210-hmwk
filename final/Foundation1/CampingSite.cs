using System;

// CampingSiteVideo.cs
// Specialized class for camping sites videos.
// Demonstrate Abstractionand add a new property while reusing base class features.

namespace BFAdventureVideos
{
    //videos for camping sites: RV pads, tents, yurts, etc.
    // Shows a subclass extending the base without revealing its internals processes.
    public class CampingSiteVideo : ThemedVideo
    {
        // Public Property (New Concept for This Class)
        public string SiteType { get; }

        //Constructor – Builds on the base and adds SiteType
        public CampingSiteVideo(string title, string author, int length, string siteType)
            : base(title, author, length, "Camping Site")
        {
            SiteType = string.IsNullOrWhiteSpace(siteType)
                ? "General Site"
                : siteType.Trim();
        }
    }

}