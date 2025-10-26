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

    }
}