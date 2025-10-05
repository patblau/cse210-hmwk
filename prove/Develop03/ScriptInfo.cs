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

      