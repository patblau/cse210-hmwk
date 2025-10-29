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

        // ---- Counts (your main goal) ----
        public int GetVideoCount() => _videos.Count;

        public int GetTotalComments()
        {
            int total = 0;
            foreach (var v in _videos)
                total += v.GetCommentCount();
            return total;
        }
        
        // ---- Counts for main goal ----
        public int GetVideoCount() => _videos.Count;

        public int GetTotalComments()
        {
            int total = 0;
            foreach (var v in _videos)
                total += v.GetCommentCount();
            return total;
        }

        // ---- Nice-to-haves (optional) ----
        public IEnumerable<Video> FindByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author)) yield break;
            foreach (var v in _videos)
                if (v.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                    yield return v;
        }

        public IEnumerable<Video> TopByEngagement(int count)
        {
            if (count <= 0) return Enumerable.Empty<Video>();
            return _videos.OrderByDescending(v => v.GetEngagementScore())
                          .Take(count);
        }
        
        
        }

        

    }
}
