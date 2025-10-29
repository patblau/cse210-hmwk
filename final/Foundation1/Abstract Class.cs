using System;
using System.Reflection;
using System.Transactions;

// FacilityVideo.cs
// Specialized class for facility-related videos.
// Uses Abstraction with focued property usage
// by using the base Video functions.


namespace BFAdventureVideos
{
    public class Video
    {
    
    //Conductors strings for title arthor, and videoLength
    public Video(string title, string author, int videoLength)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim();
            Author = string.IsNullOrWhiteSpace(author) ? "BFAdventure" : author.Trim();
            VideoLength = Math.Max(0, videoLength);
        }

        // Public Methods (The Interface)
        public void AddComment(Comment c)
        {
            if (c != null)
                _comments.Add(c);
        }

        public void AddKeyword(string word)
        {
            if (!string.IsNullOrWhiteSpace(word))
                _keywords.Add(word.Trim().ToLower());
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }
        //Display
        public void Display()
        {
            Console.WriteLine($"Title : {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {VideoLength} seconds");
            Console.WriteLine($"Comments: {v.GetCommentCount()}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
