using System;
using System.Collections.Generic;
using System.Linq;

namespace CardInventory
{
    // A collection of related baseball cards (e.g., "1989 Upper Deck", "1990 Topps Traded").
    // Encapsulation: holds a private list; exposes read-only view and safe methods.

    public class Set
    {
        private readonly List<Card> _cards = new();

        public string Name { get; }

        public Set(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Untitled Set" : name.Trim();
        }
       
       // Read-only view (prevents outside code from adding/removing directly)
        public IReadOnlyList<Card> Cards => _cards;

        public void AddCard(Card card)
        {
            if (card != null) _cards.Add(card);
        }

       

    }
}