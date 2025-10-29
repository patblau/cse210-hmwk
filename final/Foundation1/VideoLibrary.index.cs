using System;using System;
using System.Collections.Generic;
using System.Linq;

public class VideoLibrary
{
    public class VideoLibrary
    {
        private readonly List<Video> _videos = new();

        // Add a single video
        public void Add(Video v)
        {
            if (v != null) _videos.Add(v);

        // Add many at once (optional convenience)
        public void AddRange(IEnumerable<Video> videos)
        {
            if (videos == null) return;
            foreach (var v in videos) Add(v);
        }
        }
    }
}
