using System;


//Program.cs
// Demo for Program 2: Encapsulation with Cards

namespace CardInventory
{

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

        // Create sets and group related cards (encapsulated)
        var set89UD = collector.CreateSet("1989 Upper Deck Stars");
            set89UD.AddCard(c1);
        
        var setTopps90s = collector.CreateSet("1990s Topps Favorites");
        setTopps90s.AddCard(c2);
        setTopps90s.AddCard(c4);
        



        }
    }
}