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
        // Create a List to hold all video objects.

        List<Video> videos = new List<Video>();

        // Create different video types.
        // Each class shares the same public interface from Video, while having its own specialized data.

        var v1 = new FacilityVideo(
            "Facility Tour: Lodges & Outdoor Kitchens",
            "BFAdventure",
            210,
            "Main Lodge and Outdoor Kitchen");
        v1.AddComment(new Comment("Jamie", "Loved the pavilions!"));
        v1.AddComment(new Comment("Chris", "Facilities look so clean!"));

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


        
    