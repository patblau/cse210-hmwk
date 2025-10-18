using System;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

class Dev5.ProgramGoals
{
    static void Main(string[] args)
    {
        //to refer to MangerFile.cs
        ManagerFile manager = new ManagerFile();

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

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoalInteractive();
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.RecordEventInteractive();
                    break;
                case "4":
                    manager.SaveInteractive();
                    break;
                case "5":
                    manager.LoadInteractive();
                    break;
                case "6":
                    Console.WriteLine("\nYour current score is: {manager.Score}");
                    break;
                case "7":
                    manager.ReminderSetingsInteractive();
                    break;    
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.Write("\nPress Enter to continue...");
            Console.ReadLine();             
        }
    }
}
    