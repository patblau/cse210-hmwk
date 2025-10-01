namespace Develop03
{
    
    // Stores a scripture reference (single verse or range).
    // Examples: John 3:16  |  Proverbs 3:5–6 
   
    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int EndVerse { get; private set; }

        // Single verse constructor
        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = verse;
        }

        // Verse range constructor
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            return StartVerse == EndVerse
                ? $"{Book} {Chapter}:{StartVerse}"
                : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}
