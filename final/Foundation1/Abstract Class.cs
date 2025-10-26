using System;

// FacilityVideo.cs
// Specialized class for facility-related videos.
// Uses Abstraction with focued property usage
// by using the base Video functions.


namespace BFAdventureVideos
{
    public class FacilityVideo : ThemedVideo
    { 
    // Private Fields (Hidden Data) to stor coment and keywords
        
    private readonly List<Comment> _comments = new();
        private readonly List<string> _keywords = new();

    //Public Properties (Part of the Interface), ReadOnly title, author, VideoLength)
    public string Title { get; }
    public string Author { get; }
    public int VideoLength { get; }
    public IReadOnlyList<Comment> Comments => _comments;
    public IReadOnlyList<string> Keywords => _keywords;
    
    }

}