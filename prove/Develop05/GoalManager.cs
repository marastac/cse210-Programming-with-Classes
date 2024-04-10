using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> goals;
    private int score;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");

            Console.Write("\nEnter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayPlayerInfo();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    CreateGoal();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    SaveGoals();
                    break;
                case 7:
                    LoadGoals();
                    break;
                case 8:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    private void ListGoalNames()
    {
        Console.WriteLine("\nList of Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"- {goal.ShortName}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nDetails of Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nCreating a new goal:");
        Console.Write("Enter goal type (Simple/Eternal/Checklist): ");
        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal;
        switch (type.ToLower())
        {
            case "simple":
                goal = new SimpleGoal(name, description, points);
                break;
            case "eternal":
                goal = new EternalGoal(name, description, points);
                break;
            case "checklist":
                Console.Write("Enter target number of completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for achieving the target: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                return;
        }

        goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nRecording an event:");
        Console.WriteLine("Select a goal to record event for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].ShortName}");
        }
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            Goal selectedGoal = goals[choice];
            int pointsEarned = selectedGoal.RecordEvent();
            score += pointsEarned;
            Console.WriteLine($"Event recorded. You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid choice. No event recorded.");
        }
    }

    private void SaveGoals()
    {
        // Code to save goals to a file
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        // Code to load goals from a file
        Console.WriteLine("Goals loaded successfully.");
    }
}
