using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your rating? ");
        float rating;
        if (!float.TryParse(Console.ReadLine(), out rating))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        char letter;

        if (rating >= 90)
        {
            letter = 'A';
        }
        else if (rating >= 80)
        {
            letter = 'B';
        }
        else if (rating >= 70)
        {
            letter = 'C';
        }
        else if (rating >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        Console.WriteLine($"Your grade letter is: {letter}");

        if (rating >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard. You'll do better next time!");
        }
    }
}
