using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through deep breathing.", 60)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Prepare to begin deep breathing...");
        ShowCountDown(3);

        Console.WriteLine("Breathe in...");
        ShowSpinner(_duration / 2);

        Console.WriteLine("Breathe out...");
        ShowSpinner(_duration / 2);

        DisplayEndingMessage();
    }
}
