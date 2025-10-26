using System;
using System.Collections.Generic;
using System.Linq;



// Collector.cs
// Manages owner details and collection actions
// A collector with a master inventory and optional named sets.
// Encapsulation: lists are private; actions are provided via methods.

namespace CardInventory
{

    public class Collector
    {
        private readonly List<Card> _inventory = new();
        private readonly List<Set> _sets = new();

        public string Name { get; }
        public string Email { get; }

        public Collector(string name, string email)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Collector" : name.Trim();
            Email = string.IsNullOrWhiteSpace(email) ? "unknown@example.com" : email.Trim();
        }

        // Inventory actions
        public void AddCardToInventory(Card card)
        {
            if (card != null) _inventory.Add(card);
        }

        public bool RemoveCardFromInventory(Card card)
        {
            // also remove from any set that contains it
            if (card == null) return false;
            foreach (var s in _sets)
                s.RemoveCard(card);
            return _inventory.Remove(card);
        }

        // Set actions
        public Set CreateSet(string name)
        {
            var s = new Set(name);
            _sets.Add(s);
            Return s;
        }

        public bool DeleteSet(Set set)
        {
            return set != null && _sets.Remove(set);
        }

        public decimal TotalCollectionValue()
        {
            return _inventory.Sum(c => c.ValueUsd);
        }

        public override string ToString()

            => $"{Name} — {Inventory.Count} cards across {_sets.Count} sets — total ${TotalCollectionValue():0.00}";
    }
}
