using System;
using System.Collections.Generic;

public class Scriptures
{
    private readonly Reference _reference;
    private readonly List<Word> _words = new List<Word>();
    private readonly Random _random = new Random();
    private readonly string _originalText;

    public Scriptures(Random random)
    {
        this _radom = random;
    }

    public class ScriptureInfo
{
    public Reference Reference { get; }
    public string Text { get; }

    public ScriptureInfo(Reference reference, string text)
    {
        Reference = reference;
        Text = text;
    }
}
    public Scriptures(Reference reference, string text)
    {
        _reference = reference;
        // Simple split on spaces; punctuation stays attached
        var parts = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in parts) _words.Add(new Word(p));
    }

    public void DisplayInline()
    {
        foreach (var w in _words)
        {
            Console.Write(w);
            Console.Write(' ');
        }
    }

    // Hide up to 'count' random *visible* words
    public int HideRandomWords(int count = 3)
    {
        var visible = new List<int>();
        for (int i = 0; i < _words.Count; i++)
            if (!_words[i].IsHidden()) visible.Add(i);

        if (visible.Count == 0) return 0;

        int hidden = 0;
        for (int i = 0; i < count && visible.Count > 0; i++)
        {
            int pick = _random.Next(visible.Count);
            _words[visible[pick]].Hide();
            visible.RemoveAt(pick); // don’t re-pick the same word this round
            hidden++;
        }
        return hidden;
    }

    public bool AllHidden()
    {
        for (int i = 0; i < _words.Count; i++)
            if (!_words[i].IsHidden()) return false;
        return true;
    }
}