class WritingAssign
{
    //Represents Writing Assignments. Base field from Assignment
    public class WritingAssign : Assignment
    {
        private string _title;

        public WritingAssign(string sturdentName, string topic, string section, string problems)
            : base(sturdentName, topic)
        {
            _title = title ?? string.Empty;
        }
        public string GetWritingInfo() => $"Section{_title} Problems {GetStudentName()}"; 
    }
}