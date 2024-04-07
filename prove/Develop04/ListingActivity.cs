using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 60)
    {
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Think about: {randomPrompt}");
        ShowCountDown(5);

        Console.WriteLine("Start listing...");
        List<string> itemsListed = GetListFromUser();

        Console.WriteLine($"You listed {itemsListed.Count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> itemsListed = new List<string>();
        string item;
        do
        {
            Console.WriteLine("Enter an item (or type 'done' to finish): ");
            item = Console.ReadLine();
            if (item.ToLower() != "done")
                itemsListed.Add(item);
        } while (item.ToLower() != "done");

        return itemsListed;
    }
}
