using System;
using System.Diagnostics;
using System.Threading;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _durationSeconds;

    public Activity(string name, string description)
    {
        _activityName = name;
        _description  = description;
    }

    protected abstract void Execute();

    protected virtual void StartActivity()
    {
        Console.WriteLine($"--- {_activityName} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _durationSeconds = int.Parse(Console.ReadLine() ?? "30");
        Console.Write("Get ready ");
        Spinner(3);
        Console.WriteLine();
    }
    public void Run()
    {
        StartActivity();
        Execute();
        EndActivity();
    }

    protected virtual void EndActivity()
    {
        Console.Write("\nGood job! ");
        Spinner(2);
        Console.WriteLine($"\nYou completed {_activityName} for {_durationSeconds} seconds.");
    }

    protected void Spinner(int seconds)
    {
        char[] frames = { '|', '/', '-', '\\' };
        var sw = Stopwatch.StartNew();
        int i = 0;
        while (sw.Elapsed.TotalSeconds < seconds)
        {
            Console.Write($"\r{frames[i++ % frames.Length]}");
            Thread.Sleep(120);
        }
        Console.Write("\r ");
    }
}