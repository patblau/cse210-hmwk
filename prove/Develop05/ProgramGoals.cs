
using System;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

class ProgramGoals
{
    static void Main(string[] args)
    {
        // Refere to Manager to handle goals, score, save/load, reminders, and rewards.
        ManagerFile manager = new ManagerFile();

        // One-time intro about rewards & savings
        ShowRewardsIntro();
        Console.Write("Press Enter to continue...");
        Console.ReadLine();

        while (true)
        {
            // Check for reminder ping (e.g., 7:00 PM) each loop
            manager.TickReminders();

            Console.Clear();
            Console.WriteLine("===My Eternal Quest===");
            Console.WriteLine($"Score : {manager.Score}   (Level {GoalManager.ComputeLevel(manager.Score)})");
            Console.WriteLine($"Reward: {manager.Score / 100} Dove chocolate square(s)");
            Console.WriteLine($"Savings from points: ${manager.SavingsDollars}");
            Console.WriteLine();
            Console.WriteLine("1) Create new goal");
            Console.WriteLine("2) List goals");
            Console.WriteLine("3) Record Event");
            Console.WriteLine("4) Save goals");
            Console.WriteLine("5) Load goals");
            Console.WriteLine("6) Reminder settings");
            Console.WriteLine("7) Show score summary");
            Console.WriteLine("0) Exit");
            Console.Write("\nWhat do you want to do?: ");

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
                    manager.ReminderSettingsInteractive();
                    break;

                case "7":
                    ShowScoreSummary(manager);
                    Pause();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Pause();
                    break;
            }
        }
    }

    // Helpers
   static void WriteHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"=== {title} ===");
        Console.ResetColor();
    }


    }
}

