using System;
using System.ComponentModel;
using System.Dynamic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
namespace BFAdventureVideos
{
    //Value object for a video comment</summary>
    public class Comment
    {
        public string CommenterName { get; }
        public string Text { get; }

        public Comment(string commenterName, string text)
        {
            CommenterName = string.IsNullOrWhiteSpace(commenterName)
            ? "Anonymous"
            : commenterName.Trim();

            Text = string.IsNullOrWhiteSpace(text)
                ? "(no comment)"
                : text.Trim();
        }
    }
 }