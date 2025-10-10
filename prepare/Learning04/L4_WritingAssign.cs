using System;
public class L4_WritingAssign : L4_Assignment
{
    private string _title;

    public L4_WritingAssign(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title ?? string.Empty;
    }

    public string GetWritingInfo()
    {
        // This line is fine once GetStudentName() exists cleanly in the base class
        return $"{_title} by {GetStudentName()}";
    }
}