using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml;

namespace BFAdventureVideos
{
    // Base class; title, author, length, comments, and keywords.
    public class Video
    {
        // Internal storage – hidden from outside access
        private readonly List<Comment> _comments = new();
        private readonly List<string> _keywords = new();

        // Public read-only properties (the “interface”)
        public string Title { get; }
        public string Author { get; }
        public int VideoLength { get; }

        // Read-only views of private data (still safe)
        public IReadOnlyList<Comment> Comments => _comments;
        public IReadOnlyList<string> Keywords => _keywords;


        // Constructor – enforces required info and validates input
        public Video(string title, string author, int videoLength)
        {
            Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim();
            Author = string.IsNullOrWhiteSpace(author) ? "BFAdventure" : author.Trim();
            VideoLength = Math.Max(0, videoLength);
        }

        // Public void methods 
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
     // Utility behavior
        public void Display()
        {
            Console.WriteLine($"Title : {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {VideoLength} seconds");
            Console.WriteLine($"Comments: {GetCommentCount()}");
        }
       
    }
}


    

       


        
       








       
    

        
    


