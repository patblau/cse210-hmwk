using System;


Program.cs
// Demo for Program 2: Encapsulation with Cards

class Program
{
    static void Main()
    {
        var collector = new Collector("Pat Blau", "pat@example.com");

        // Create some cards
        var c1 = new Card("Ken Griffey Jr.", 1989, "Upper Deck", "NM", 120.00m);
        var c2 = new Card("Frank Thomas", 1990, "Topps", "EX", 35.50m);
        var c3 = new Card("Cal Ripken Jr.", 1992, "Fleer Ultra", "VG", 18.00m);
        var c4 = new Card("Ryne Sandberg", 1984, "Topps", "EX", 60.00m);
        {
            Console.WriteLine("Hello Foundation2 World!");
        }
    }
}