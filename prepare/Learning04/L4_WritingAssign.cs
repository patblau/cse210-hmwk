namespace Learning04
{
    public class L4_WritingAssign : L4_Assignment
    {
        private string _title;

        public L4_WritingAssign(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title ?? string.Empty;
        }

        // Keep ONLY this one method
        public string GetWritingInfo()
        {
            return $"{_title} by {GetStudentName()}";
        }
    }
}