using System;
using System.Collections.Generic;
using System.Linq;

namespace Develop03
{
    /// <summary>Holds the reference and words; hides words over time.</summary>
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private readonly Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            // Split on spaces; keep punctuation attached to words (simple approach)
            _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                         .Select(w => new Word(w))
                         .ToList();
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(_reference);
            Console.WriteLine();
            foreach (var word in _words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Hides up to 'count' randomly chosen visible words.
        /// Returns the number actually hidden this round.
        /// </summary>
        public int HideRandomWords(int count = 3)
        {
            var visible = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                    visible.Add(i);
            }
            if (visible.Count == 0) return 0;

            int hidden = 0;
            for (int i = 0; i < count && visible.Count > 0; i++)
            {
                int pick = _random.Next(visible.Count);
                int wordIndex = visible[pick];
                _words[wordIndex].Hide();
                visible.RemoveAt(pick); // ensure we don't pick the same word twice
                hidden++;
            }
            return hidden;
        }

        public bool AllHidden()
        {
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                    return false;
            }
            return true;
        }
    }
}
