using System;
using System.Collections.Generic;


    // Base class; title, author, length, comments, and keywords.
    public class Video
{    
    // fields
    private string _title;
    private string _author;
    private int _lengthSeconds;
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
    public string Title
    {
        get => _title;
        private set => _title = value;
    }

    public string Author
    {
        get => _author;
        private set => _author = value;
    }

    public int VideoLength
    {
        get => _videoLength;
        private set => _videoLength = value;
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
        Console.WriteLine($"Comments: {ValidationType.GetCommentCount()}");
       
    }
}


    

       


        
       








       
    

        
    


