using System;
using System.Collections.Generic;

public class ScriptInfo
{
    private readonly Reference Reference { get;}
    public string Text { get; }

    public ScriptInfo(Reference reference, string text)
    {
        Reference = reference ?? new Reference("", 0, 0);
        Text = text ?? string.Empty;
    }
    private readonly List<Word> _words = new List<Word>();
    private readonly Random _random = new Random();
    private readonly string _originalText;

    public int TotalCount => _words.Count;
    public int HiddenCount { get { int c=0; foreach (var w in _words) if (w.IsHidden()) c++; return c; } }
    public double HiddenPercent => _words.Count == 0 ? 0 : HiddenCount * 100.0 / _words.Count;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _originalText = text;
        var parts = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in parts) _words.Add(new Word(p));
    }

    public void DisplayInline()
    {
        foreach (var w in _words) { Console.Write(w); Console.Write(' '); }
    }

    public void HideRandomWords(int count)
    {
        var visible = new List<int>();
        for (int i=0; i<_words.Count; i++) if (!_words[i].IsHidden()) visible.Add(i);
        for (int i=0; i<count && visible.Count>0; i++)
        {
            int pick = _random.Next(visible.Count);
            _words[visible[pick]].Hide();
            visible.RemoveAt(pick);
        }
    }

    public void RevealOneRandomHidden()
    {
        var hidden = new List<int>();
        for (int i=0; i<_words.Count; i++) if (_words[i].IsHidden()) hidden.Add(i);
        if (hidden.Count == 0) return;
        _words[hidden[_random.Next(hidden.Count)]].Reveal();
    }

    public void Reset()
    {
        _words.Clear();
        var parts = _originalText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in parts) _words.Add(new Word(p));
    }

    public bool AllHidden()
    {
        foreach (var w in _words) if (!w.IsHidden()) return false;
        return true;
    }
}