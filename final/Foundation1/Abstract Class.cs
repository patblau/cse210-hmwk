using System;
using System.Reflection;
using System.Transactions;

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
    
    //Conductors strings for title arthor, and videoLength
    public Video(string title, string author, int videoLength)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim();
            Author = string.IsNullOrWhiteSpace(author) ? "BFAdventure" : author.Trim();
            VideoLength = Math.Max(0, videoLength);
        }

        // Public Methods (The Interface)
        public void AddComment(Commemt c)
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
    
}