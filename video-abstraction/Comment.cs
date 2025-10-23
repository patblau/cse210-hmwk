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

       