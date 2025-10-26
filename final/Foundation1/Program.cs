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

        