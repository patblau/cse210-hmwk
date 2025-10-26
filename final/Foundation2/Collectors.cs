using System;
using System.Collections.Generic;
using System.Linq;

// Collector.cs
// Manages owner details and collection actions
// A collector with a master inventory and optional named sets.
// Encapsulation: lists are private; actions are provided via methods.



public class Collector
{
    private readonly List<Card> _inventory = new();
    private readonly List<Set>  _sets      = new();

    public string Name  { get; }
    public string Email { get; }

    public Collector(string name, string email)
        {
            Name  = string.IsNullOrWhiteSpace(name) ? "Unnamed Collector" : name.Trim();
            Email = string.IsNullOrWhiteSpace(email) ? "unknown@example.com" : email.Trim();
 }