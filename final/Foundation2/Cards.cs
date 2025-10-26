using System;
using System.Security.Cryptography.X509Certificates;

// A baseball card with private state (player, year, brand, condition, value).
// Encapsulation: state is guarded; changes go through methods/properties.

// Public class 
public class Card
{
    // Private backing fields (hidden)
    private string _player;
    private int    _year;
    private string _brand;
    private string _condition;
    private decimal _valueUsd;
}

