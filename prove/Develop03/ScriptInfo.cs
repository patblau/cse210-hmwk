using System;
using System.Collections.Generic;

public class ScriptInfo
{
    public Reference Reference { get; }   // <-- must be public to be accessible
    public string Text { get; }

    public ScriptInfo(Reference reference, string text)
    {
        Reference = reference ?? throw new ArgumentNullException(nameof(reference));
        Text = text ?? string.Empty;
    }
}

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words = new List<Word>();
    private readonly Random _random = new Random();
    private readonly string _originalText;

    public int TotalWords => _words.Count;
    public int HiddenWords int _words.Count
    {
        get
        {
            int count = 0;
            foreach (var word in _words)
            {
                if (word.IsHidden) count++;
            }
            return count;
        }           
    }    
       public double HiddenPercent => _words.Count == 0 ? 0 : HiddenCount * 100.0 / _words.Count;

        public Scripture(Reference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            _originalText = text ?? string.Empty;

            var parts = _originalText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in parts)
                _words.Add(new Word(p));
        }

      