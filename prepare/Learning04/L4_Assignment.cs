using System;


class L4_Assignment
{
    // Bass class for all assignments
    //Uses private number variiables and exposes a public accessor for the student name so
    //derived classes can be use it.

    public class Assignment
    {
        private string _studentName;
        private string _topic;
    
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName ?? string.Empty;
            _topic = topic ?? string.Empty;
        }
    public string GetStudentName() => _studentName;
    public string GetTopic() => _topic;

    public string GetSummary() => $"{_studentName} - {_topic}";
    }
}
