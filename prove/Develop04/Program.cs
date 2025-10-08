using System;
{
    public class Assignment
    {
        // member variables
        public string _studentName;
        private string _topic;

        //constructor
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName ?? string.Empty;
            _topic = topic ?? string.Empty;
        }

        // method to return Name and Topic
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
    }
}

        
       