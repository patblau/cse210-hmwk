using System; 
public class L4_WritingAssign : L4_Assignment
{
    private string _title;

    // Constructor for studentName, topic, and title
    public L4_WritingAssign(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title ?? string.Empty;
    }

    // Return writing info like "The Causes of World War II by Mary Waters"
    public string GetWritingInfo()
    {
        return $"{_title} by {GetStudentName()}";
    }
}