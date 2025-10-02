public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text) { _text = text ?? string.Empty; _isHidden = false; }
    public void Hide() => _isHidden = true;
    public void Reveal() => _isHidden = false;
    public bool IsHidden() => _isHidden;

    public override string ToString()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}