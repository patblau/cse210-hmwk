
using System;
using System.Runtime.CompilerServices;
namespace Prove.Develop05
{
    public class Reminder
    {
        private TimeSpan _reminderTime;
        private bool _isEnabled;
        private string _message;

        public Reminder(int hour, int minute, string message = "")
        {
            _reminderTime = new TimeSpan(hour, minute, 0);
            _isEnabled = true;
        }

       ();
        }
    }
}
