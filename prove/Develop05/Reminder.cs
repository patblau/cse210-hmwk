
using System;
using System.Runtime.CompilerServices;
namespace Prove.Develop05
{
    public class Reminder
    {
        private TimeSpan _reminderTime;
        private bool _isEnabled;

        public Reminder(int hour, int minute, bool enabled = true)
        {
            _reminderTime = new TimeSpan(hour, minute, 0);
            _isEnabled = enabled;
        }

        // Let usser choose to enable/disable reminder
        public bool IsEnabled => _isEnabled;
        public TimeSpan ReminderTime => _reminderTime;
        public int Hour => _reminderTime.Hours;
        public int Minute => _reminderTime.Minutes;

        public void Enable() { _isEnabled = true; }
        public void Disable() { _isEnabled = false; }
        public void Toggle() { _isEnabled = !_isEnabled; }

        //Daily Reminder time (24 hr clock)
        public void SetTime(int hour, int minute)
        {
            if (hour < 0 || hour > 23) throw new ArgumentOutOfRangeException(nameof(hour));
            if (minute < 0 || minute > 59) throw new ArgumentOutOfRangeException(nameof(minute));
            _reminderTime = new TimeSpan(hour, minute, 0);
        }

        /// <summary>Call this regularly (e.g., once per menu loop) to show the reminder at the target minute.</summary>
        public void CheckAndNotify()
        {
            if (!_isEnabled) return;

            TimeSpan now = DateTime.Now.TimeOfDay;

            // Notify if we're within 60 seconds of the target time.
            if (Math.Abs((now - _reminderTime).TotalSeconds) < 60)
            {
                ShowReminder();
            }
        }

        private void ShowReminder()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nReminder: Record your Eternal Quest daily goal progress!");
            Console.WriteLine("   Scriptures, prayer, service — don’t forget to update your score!\n");
            Console.ResetColor();
        }


        // ---------- Save / Load helpers for ManagerFile ----------

        public string ToConfigLine()
        {
            // Example: REMINDER|1|19:00
            string enabled = _isEnabled ? "1" : "0";
            return $"REMINDER|{enabled}|{Hour:D2}:{Minute:D2}";
        }

        public static Reminder FromConfigLine(string line)
        {
            // Accepts lines starting with REMINDER|{0|1}|HH:MM
            // Fallback to 19:00 enabled if parse fails.
            try
            {
                var parts = line.Split('|');
                if (parts.Length >= 3 && parts[0] == "REMINDER")
                {
                    bool enabled = parts[1] == "1";
                    var hm = parts[2].Split(':');
                    int h = int.Parse(hm[0]);
                    int m = int.Parse(hm[1]);
                    return new Reminder(h, m, enabled);
                }
            }
            catch { /* ignore parse errors; fall back below */ }

            return new Reminder(19, 0, true);
        }
    }
}


        
