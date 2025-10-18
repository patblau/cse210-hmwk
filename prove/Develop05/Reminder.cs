
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

        public void Enable()
        {
            _isEnabled = true;
        }
       
        public void Disable()
        {   
            _isEnabled = false;
        }
        public void CheckAndNotify()
        {
            if (!_isEnabled) return;
            TimeSpan now = DateTime.Now.TimeOfDay;
            if (Math.Abs((now - _reminderTime).TotalMinutes) < 1)
            {
                ShowReminder();
            }
        } 
        
        private void ShowReminder()
        {
            Console.WriteLine($"\nReminder: Record your Eternal Quest daily goal progress!");
            Console.WriteLine("  Don’t forget to update your score!\n");
            Console.ResetColor();
        } 

    }
}

        