using System;
using System.Collections.Generic;

public class Scriptures
{
    private readonly Reference _reference;
    private readonly List<Word> _words = new List<Word>();
    private readonly Random _random = new Random();
    private readonly string _originalText; 

    // Stats (handy for UI)
    public int TotalCount => _words.Count;
    public int HiddenCount
    {
        get
        {
            int c = 0;
            for (int i = 0; i < _words.Count; i++)
            {
                if (_words[i].IsHidden()) c++;
            }
            return c;
        }
    }
    public double HiddenPercent => _words.Count == 0 ? 0 : (HiddenCount * 100.0) / _words.Count;

    public Scriptures(Reference reference, string text)
    {
        _reference = reference;
        _originalText = text ?? string.Empty;

        // Simple split on spaces; punctuation stays attached
        var parts = _originalText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length; i++)
        {
            _words.Add(new Word(parts[i]));
        }
    }




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
    } // Renders the verse inline: hidden words appear as underscores
    public void DisplayInline()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            Console.Write(_words[i]);
            Console.Write(' ');
        }
    }

    // Hides up to 'count' random words that are still visible (unique picks per round)
    public int HideRandomWords(int count = 3)
    {
        var visible = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden()) visible.Add(i);
        }
        if (visible.Count == 0) return 0;

        int hidden = 0;
        for (int i = 0; i < count && visible.Count > 0; i++)
        {
            int pick = _random.Next(visible.Count);
            int idx = visible[pick];
            _words[idx].Hide();
            visible.RemoveAt(pick); // avoid re-picking the same word this round
            hidden++;
        }
        return hidden;
    }
