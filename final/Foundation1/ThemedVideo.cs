using System;

namespace BFAdventuresVideo
{
    public class ThemedVideos : BFAdventuresVideo
    {
        // Visable themes
        public string Theme { get; }
        public ThemedVideo(string title, string author, string theme, int length)
        : base(title, author, length)
        {
            Theme = string.IsNullOrWhitspace(theme) ? "General" : theme.Trim();
        }
   } 
} 


