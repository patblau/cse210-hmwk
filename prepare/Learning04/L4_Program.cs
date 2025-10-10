using System;

class L4_Program
{
    static void Main(string[] args)
    {
        // --- Test base class ---
        var a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        // Expected:
        // Samuel Bennett - Multiplication

        Console.WriteLine();

        // --- Test MathAssignment ---
        var m1 = new MathAssign("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());
        // Expected:
        // Roberto Rodriguez - Fractions
        // Section 7.3 Problems 8-19

        Console.WriteLine();

        // --- Test WritingAssignment ---
        var w1 = new WritingAssign("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInfor());
        // Expected:
        // Mary Waters - European History
        // The Causes of World War II by Mary Waters
    }
}
