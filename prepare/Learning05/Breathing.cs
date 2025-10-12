using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in, holding, and breathing out slowly. " +
        "Clear your mind and focus on your breathing.")
    { }

    protected override void RunCore()
    {
        // Settings: 6 full rounds, each phase = 3 seconds
        int cycles = 6;
        int inhaleSeconds = 3;
        int holdSeconds   = 3;
        int exhaleSeconds = 3;

        Console.WriteLine($"\nYou will complete {cycles} rounds of deep breathing.");
        Console.WriteLine($"Each round: inhale {inhaleSeconds}s → hold {holdSeconds}s → exhale {exhaleSeconds}s.\n");
        ShowSpinner(2);

        for (int i = 1; i <= cycles; i++)
        {
            Console.WriteLine($"Round {i} of {cycles}:");

            // Inhale
            Console.Write("Breathe in... ");
            ShowCountdown(inhaleSeconds);
            Console.WriteLine();

            // Hold
            Console.Write("Hold... ");
            ShowCountdown(holdSeconds);
            Console.WriteLine();

            // Exhale
            Console.Write("Breathe out... ");
            ShowCountdown(exhaleSeconds);
            Console.WriteLine();

            Console.WriteLine(); // spacing between rounds
        }

        Console.WriteLine("Take a moment to notice how you feel...");
        ShowSpinner(3);
    }
}