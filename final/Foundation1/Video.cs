using System;
using System.Collections.Generic;
using BFAdventuresVideo;


    // Base class; title, author, length, comments, and keywords.
    public class Video
{    
    // fields
    private string _title;
    private string _author;
    private int _videoLength;
    private int _views;
    private int _likes;
    private int _dislikes;
    
    private readonly List<Comment> _comments = new();
    private readonly List<string> _keywords = new();


    // Constructor – enforces required info and validates input
    public Video(string title, string author, int videoLength)
    {
        Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim();
        Author = string.IsNullOrWhiteSpace(author) ? "BFAdventure" : author.Trim();
        VideoLength = Math.Max(0, videoLength);
    }

    // ===== Properties =====
    public string Title { get => _title; private set => _title = value; }
    public string Author { get => _author; private set => _author = value; }
    public int VideoLength { get => _videoLength; private set => _videoLength = value; }
        
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

    public void AddEngagement(int views, int likes, int dislikes)
    {
        _views = Math.Max(0, views);
        _likes = Math.Max(0, likes);
        _dislikes = Math.Max(0, dislikes);
    }

    // Count number of comments
    public int GetCommentCount() => _comments.Count;

    // Bonus: simple engagement score for fun display
    public double GetEngagementScore() => _likes - _dislikes + GetCommentCount();
    
    // Utility behavior
    public void Display()
    {
        Console.WriteLine($"Title : {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {VideoLength} seconds");
        Console.WriteLine($"Views: {_views}, Likes: {_likes}, Dislikes: {_dislikes}");
        Console.WriteLine($"Engagement Score: {GetEngagementScore():0.0}");
    }
}


    

       


        
       








       
    

        
    


