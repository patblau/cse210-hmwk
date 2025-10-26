using System;

namespace BFAdventureVideo
{
    // ActivityVideo.cs
    // Specialized class for videos about activities and events.
    // Demonstrates Abstraction:


    public class ActivityVideo : ThemedVideo
{
    // Public Property – simple, meaningful interface addition
    public string ActivityType { get; }

    // Constructor – uses base setup and adds ActivityType
    public ActivityVideo(string title, string author, int length, string activityType)
        : base(title, author, length, "Activity")
    {
        ActivityType = string.IsNullOrWhiteSpace(activityType)
            ? "General Activity"
            : activityType.Trim();
    }
 }
    
}