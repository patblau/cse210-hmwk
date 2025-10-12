using System;
using System.Threading;

namespace MindfulnessApp
{
    /// <summary>
    /// Abstract base class for all activities.
    /// Holds shared attributes, start/end messages, and simple animations.
    /// </summary>
    public abstract class Activity
    {
        // Encapsulated state
        private readonly string _activityName;
        private readonly string _description;

        // Duration is set during StartActivity(); subclasses can read it
        protected int DurationSeconds { get; private set; }

        protected string ActivityName => _activityName;
        protected string Description  => _description;

        protected Activity(string name, string description)
        {
            _activityName = name ?? string.Empty;
            _description  = description ?? string.Empty;
        }

        /// <summary>Template method: common flow for every activity.</summary>
        public void Run()
        {
            StartActivity();
            RunCore();          // implemented by each derived class
            EndActivity();
        }

        /// <summary>Common starting message + ask for duration + short pause.</summary>
        protected void StartActivity()
        {
            Console.Clear();
            Console.WriteLine($"== {ActivityName} ==");
            Console.WriteLine(Description);
            Console.WriteLine();

            DurationSeconds = AskForDurationSeconds();
            Console.WriteLine("\nGet ready to begin...");
            ShowSpinner(3);
        }

        /// <summary>Common ending message with a short pause.</summary>
        protected void EndActivity()
        {
            Console.WriteLine();
            Console.WriteLine("Great job!");
            ShowSpinner(2);
            Console.WriteLine($"You completed the {ActivityName} for {DurationSeconds} seconds.");
            ShowSpinner(2);
        }

        /// <summary>Derived classes must provide their core logic.</summary>
        protected abstract void RunCore();

        // ---------- Shared helpers ----------

        protected int AskForDurationSeconds()
        {
            while (true)
            {
                Console.Write("How long, in seconds, would you like for your session? ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int s) && s > 0) return s;
                Console.WriteLine("Please enter a positive whole number.");
            }
        }

        /// <summary>Simple spinner animation for the given number of seconds.</summary>
        protected void ShowSpinner(int seconds)
        {
            var frames = new[] { "|", "/", "-", "\\" };
            var end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(frames[i++ % frames.Length]);
                Thread.Sleep(120);
                Console.Write("\b");
            }
        }

        /// <summary>Countdown animation: 5 4 3 2 1 (erases as it goes).</summary>
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b"); // erase the digit
            }
        }
    }
}