
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

        