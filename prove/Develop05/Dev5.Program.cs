using System;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

class ProgramGoals
{
    static void Main(string[] args)
    {
        //to refer to MangerFile.cs
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("===My Eternal Quest===");
            Console.WriteLine($"Score: {manager.Score}");
            Console.WriteLine();
            Console.WriteLine("1) Create new goal");
            Console.WriteLine("2) List goals");
            Console.WriteLine("3) Record Event");
            Console.WriteLine("4) Save goals");
            Console.WriteLine("5) Load goals");
            Console.WriteLine("6) Show goals");
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) What do you want to do?: ");
        }
    }
}