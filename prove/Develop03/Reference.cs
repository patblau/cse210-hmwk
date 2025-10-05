namespace Develop03;

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    // Single verse
    public Reference(string book, int chapter, int verse)
    {
        Book = book; 
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }

    // Verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public bool IsRange() => StartVerse != EndVerse;

    {
        return StartVerse != EndVerse;
    }

    public override string ToString()
    {
        return IsRange()
            ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}"
            : $"{Book} {Chapter}:{StartVerse}";
    }
}
