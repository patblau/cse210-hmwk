public class BaseAssignment
{
    private readonly string _studentName;
    private readonly string _topic;

    public BaseAssignment(string studentName, string topic)
    {
        _studentName = studentName ?? string.Empty;
        _topic = topic ?? string.Empty;
    }

    public string GetStudentName() => _studentName;
    public string GetTopic() => _topic;
    public string GetSummary() => $"{_studentName} - {_topic}";
}