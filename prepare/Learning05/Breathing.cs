using System;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. " +
            "Clear your mind and focus on your breathing.")
        { }

        // Core breathing loop: alternate "in" and "out" until duration is up
        protected override void RunCore()
        {
            var end = DateTime.Now.AddSeconds(DurationSeconds);

            // Simple pacing: 4 seconds in, 6 seconds out (adjust as you like)
            while (DateTime.Now < end)
            {
                int remaining = (int)(end - DateTime.Now).TotalSeconds;
                if (remaining <= 0) break;

                Console.Write("Breathe in... ");
                ShowCountdown(Math.Min(4, Math.Max(1, remaining)));
                Console.WriteLine();

                if (DateTime.Now >= end) break;

                remaining = (int)(end - DateTime.Now).TotalSeconds;
                Console.Write("Breathe out... ");
                ShowCountdown(Math.Min(6, Math.Max(1, remaining)));
                Console.WriteLine();
            }
        }
    }
}