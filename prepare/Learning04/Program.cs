using System;
using Learning04;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");

        //Test base class
        Var a1 = new Assignment("Samuel Bennet", "Multiplaction");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLIne();

        // Test MathAssignment
        Var a1 = new MathAssignment("Pat Blau", "Multiplaction"), "Fractions", "7.3", "8-19";
        Console.WriteLine(m1.GetSummary());
        Console.WriteLIne(m1.GetHomeworkList());

        //Test WritingAssignment
        Var a1 = new MathAssignment("Shelly Waters", "Multiplaction"), "European History";
        Console.WriteLine(w1.GetSummary());
        Console.WriteLIne(w1.GetWritingInformation())
    }
}