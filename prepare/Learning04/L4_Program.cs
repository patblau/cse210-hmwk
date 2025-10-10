class L4_Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");

        //Test base class
        var a1 = new Assignment("Samuel Bennet", "Multiplaction");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLIne();

        // Test MathAssignment
        var a1 = new MathAssignment("Pat Blau", "Multiplaction"), "Fractions", "7.3", "8-19";
        Console.WriteLine(m1.GetSummary());
        Console.WriteLIne(m1.GetHomeworkList());

        //Test WritingAssignment
        var a1 = new MathAssignment("Shelly Waters", "Multiplaction"), "European History";
        Console.WriteLine(w1.GetSummary());
        Console.WriteLIne(w1.GetWritingInformation())
    }
}