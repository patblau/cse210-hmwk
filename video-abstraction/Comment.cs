using System;
using System.ComponentModel;
using System.Dynamic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
namespace BFAdventureVideos
{
    /// <summary>Value object for a video comment.</summary>
    public class Comment
    {
        public string Author { get; }
        public string Text { get; }

        public Comment(string author, string text)
        {
            Author = string.IsNullOrWhiteSpace(author) ? "Anonymous" : author.Trim();
            Text   = text?.Trim() ?? string.Empty;
        }

    }
}
