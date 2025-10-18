
using Prove.Develop05;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using Microsoft.VisualBasic;


class ProgramGoals
{
    static void Main(string[] args)
    {
        // Refere to Manager to handle goals, score, save/load, reminders, and rewards.
       GoalManager manager = new GoalManager();

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
            Console.WriteLine($"Savings from points: ${manager.Score / 10}");
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
    static void Pause()
    {
        Console.Write("\nPress Enter to continue...");
        Console.ReadLine();
    }
    static bool _rewardIntroShown = false;
    static void ShowRewardsIntro()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Rewards & Savings Rules");
        Console.ResetColor();
        Console.WriteLine("- Every 100 pts = 1 Dove chocolate square  →  \"You did it. Grab a chocolate Dove Square.\"");
        Console.WriteLine("- Every 500 pts = 2 cookies                →  \"Way to go. Time for some cookies.\"");
        Console.WriteLine("- Every 1000 pts = a scoop of ice cream    →  \"You did it. Have some ice cream.\"");
        Console.WriteLine("- Every 5000 pts = a slice of cake/pie     →  \"Way to hang in there. Have a slice of cake/pie. You deserve it.\"");
        Console.WriteLine("- At 9000 pts: \"9000 points achieved. Start planning your get away.\"");
        Console.WriteLine("- Every 10,000 pts = weekend get away      →  \"Time to have some fun. Enjoy your week end. You earned it.\"");
        Console.WriteLine();
        Console.WriteLine("Savings rule: For every 100 pts achieved, add $10 to savings.");
        Console.WriteLine("Example: At 10,000 pts your savings total would be $1,000.");
        Console.WriteLine("Your rewards encourage consistency and progress — great job staying motivated!");
        Console.WriteLine();
        _rewardIntroShown = true;
    }
    static void ShowScoreSummary(GoalManager manager)
    {
        WriteHeader("Score Summary");
        Console.WriteLine($"Total Score: {manager.Score}");
        Console.WriteLine($"Current Level: {GoalManager.ComputeLevel(manager.Score)}");
        Console.WriteLine($"Total Rewards Earned: {manager.Score / 100} Dove chocolate square(s)");
        Console.WriteLine($"Total Savings from Points: ${manager.Score / 10}");
        
        
    }
}

