using System;
using System.Collections.Generic;
using System.Linq;

public class VideoLibrary
{
    private readonly List<Video> _videos = new();

    // Add one video to the library
    public void Add(Video v)
    {
        if (v != null)
            _videos.Add(v);
    }

    // Add multiple videos
    public void AddRange(IEnumerable<Video> videos)
    {
        if (videos == null) return;
        foreach (var v in videos)
            Add(v);
    }

    // Count how many videos total
    public int GetVideoCount()
    {
        return _videos.Count;
    }

    // Count all comments across all videos
    public int GetTotalComments()
    {
        int total = 0;
        foreach (var v in _videos)
        {
            total += v.GetCommentCount();
        }
        return total;
    }

    // Display summary
    public void PrintSummary()
    {
        Console.WriteLine($"Total videos tracked: {GetVideoCount()}");
        Console.WriteLine($"Total comments across all videos: {GetTotalComments()}");
    }
}
