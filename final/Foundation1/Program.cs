using System;
using System.Collections.Generic;
using BFAdventureVideos;   // Gives access to your custom classes

// Program.cs
// Entry point for BFAdventureVideos project
// Demonstrates Abstraction

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("   YouTube Video Tracker - Foundation 1");
        Console.WriteLine("==============================================");
        Console.WriteLine("This program tracks videos and their comments,");
        Console.WriteLine("allowing you to see engagement totals and counts.");
        Console.WriteLine("==============================================\n");

        // Create a List to hold all video objects.

       // Create a video library
        var library = new VideoLibrary();

        // Create different video types.
        // Each class shares the same public interface from Video, while having its own specialized data.

        // --- Video 1 ---
        var video1 = new Video("Guided Hike — Lookout Loop", "BFA Camping LLC", 720);
        video1.AddEngagement(2400, 310, 5);
        video1.AddComment(new Comment("Jamie", "Beautiful scenery!"));
        video1.AddComment(new Comment("Chris", "Love this trail!"));
        video1.AddComment(new Comment("Taylor", "Can’t wait to visit next season."));
        library.Add(video1);

        var v2 = new CampingSiteVideo(
            "Glamping Options: Cabins, Yurts, and Treehouses",
            "BFAdventure",
            180,
            "Glamping Cabins");
        v2.AddComment(new Comment("Ava", "The yurts look cozy!"));
        v2.AddComment(new Comment("Theo", "Treehouses are awesome."));

        var v3 = new ActivityVideo(
            "Water Sports & Cooking Contests",
            "BFAdventure",
            195,
            "Outdoor Cooking");
        v3.AddComment(new Comment("Lia", "I want to try the kayak race!"));
        v3.AddComment(new Comment("Ben", "That cooking contest looked fun!"));
        
        // Add all videos to the list. 
        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        // Display the video information.
        Console.WriteLine("\n=== BFAdventure Video Library ===\n");
            foreach (var v in videos)
            {
                Console.WriteLine($"Title: {v.Title}");
                Console.WriteLine($"Author: {v.Author}");
                Console.WriteLine($"Length: {v.LengthSeconds}");
                Console.WriteLine($"Comments: {v.GetCommentCount()}");
            }

        Console.WriteLine("\nAll videos displayed successfully!");
        }
       static void Main(string[] args)
    {
            
        {   
        Console.WriteLine("Hello Foundation1 World!");
        }
    }
}      


        
    