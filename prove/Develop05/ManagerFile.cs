using System;
using System.Security.Cryptography.X509Certificates;

public class GoalManager
{
    //fields and properties
    private List<GoalManager> _goal = new List<GoalManager>();
    private int _score = 0;
    public int Score => _score;

    //Menue Actions
    public void CreateGoalInteractive()
    {
        Console.Clear();
        Console.WriteLine("Create a new goal:");
        Console.WriteLine("1 Simple Goal");
        Console.WriteLine("2 Eternal Goal");
        Console.WriteLine("3 Checklist Goal");
        Console.WriteLine("\nInsert choice: ");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Disciption: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;

            case "3":
                Console.Write("Times required to complete: ");
                int target = int.Parse(Console.ReadLine() ?? "1");
                Console.Write("Bonus points when complete: ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }
    
        public void ListGoals()
        {
            Console.Clear();
            Console.WriteLine("===Your Goals===\n:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
            }
        }
            
        public void RecordEventInteractive()
        {
            Console.Clear();
            Console.WriteLine("Record an event:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals have been recorded.");
                return;
            }

            ListGoals();
            Console.Write("\nEnter goal number to record progress: ");
            int index = int.Parse(Console.ReadLine() ?? "0") - 1;

            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

        }