using static L4_Assignment;

class MathAssign
{
    //Represents Math Assignments. Base field from Assignment
    public class L4_MathAssign : L4_Assignment
    {
        private string _section;
        private string _problems;

        public L4_MathAssign(string studentName, string topic) : base(studentName, topic)
        {
        }

        public L4_MathAssign(string sturdentName, string topic, string section, string problems)
            : base(sturdentName, topic)
        {
            _section = section ?? string.Empty;
            _problems = section ?? string.Empty;
        }
        public string GetHomeworkList() => $"Section{_section} Problems {_problems}"; 
    }
}