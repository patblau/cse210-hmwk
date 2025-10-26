using System;
using System.Security.Cryptography.X509Certificates;

// A baseball card with private state (player, year, brand, condition, value).
// Encapsulation: state is guarded; changes go through methods/properties.

// Public class 
public class Card
{
    // Private backing fields (hidden)
    private string _player;
    private int _year;
    private string _brand;
    private string _condition;
    private decimal _valueUsd;

    
    // Public read-only properties (expose safely)
    public string Player     => _player;
    public int    Year       => _year;
    public string Brand      => _brand;
    public string Condition  => _condition;
    public decimal ValueUsd => _valueUsd;

    public Card(string player, int year, string brand, string condition, decimal valueUsd)
    {
        // Validation & cleanup (still simple)
        _player = string.IsNullOrWhiteSpace(player) ? "Unknown Player" : player.Trim();
        _year = Math.Max(1869, year); // first pro ball ~1869; prevents negatives
        _brand = string.IsNullOrWhiteSpace(brand) ? "Unknown Brand" : brand.Trim();
        _condition = NormalizeCondition(condition);
        _valueUsd = valueUsd < 0 ? 0 : decimal.Round(valueUsd, 2);
    }
     
     // Encapsulated updates (no direct field writes from outside)
    public void UpdateCondition(string newCondition)
    {
        _condition = NormalizeCondition(newCondition);
    }

    public void UpdateValue(decimal newValueUsd)
    {
        _valueUsd = newValueUsd < 0 ? 0 : decimal.Round(newValueUsd, 2);
    }

    private static string NormalizeCondition(string c)
    {
         // Keep it simple: normalize common labels; fall back to trimmed text
        if (string.IsNullOrWhiteSpace(c)) return "Unknown";
        var t = c.Trim().ToUpperInvariant();
        return t switch
        {
            "MINT" or "MT" => "Mint",
            "NM" or "NEAR MINT" => "Near Mint",
            "EX" or "EXCELLENT" => "Excellent",
            "VG" or "VERY GOOD" => "Very Good",
            "G" or "GOOD" => "Good",
            "P" or "POOR" => "Poor",
            _ => char.ToUpper(c[0]) + c.Trim().ToLowerInvariant()[1..] // Title-ish
        };
       
    public override string ToString()
        => $"{Year} {Brand} — {Player} ({Condition}) ${ValueUsd:0.00}";
    }
}  
    

