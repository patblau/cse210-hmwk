using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity helps you relax by guiding you to breathe in and out slowly.") { }

    protected override void Execute()
    {
        var sw = Stopwatch.StartNew();
        while (sw.Elapsed.TotalSeconds < _durationSeconds)
        {
            Console.WriteLine("Breathe in...");
            Countdown(4);
            Console.WriteLine("Breathe out...");
            Countdown(6);
        }
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }
        Console.Write("\r   \r");
    }
}
