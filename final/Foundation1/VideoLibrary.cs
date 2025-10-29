using System;
using System.Collections.Generic;
using System.Linq;

public class VideoLibrary
{
     private readonly List<Video> _videos = new();

    // Add a video to the library
    public void Add(Video v)
    {
        if (v != null) _videos.Add(v);
    }
    // Add a range of videos 
    public void AddRange(IEnumerable<Video> videos)
    {
        if (videos == null) return;
        foreach (var v in videos) Add(v);
    }