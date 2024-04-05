using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose an option: ");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.WriteLine("Enter your response:");
                        string response = Console.ReadLine();
                        journal.AddEntry(new Entry(DateTime.Now.ToShortDateString(), prompt, response));
                        break;
                    case 2:
                        Console.WriteLine("Journal Entries:");
                        journal.DisplayAll();
                        break;
                    case 3:
                        Console.WriteLine("Enter filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        Console.WriteLine("Journal saved to file successfully.");
                        break;
                    case 4:
                        Console.WriteLine("Enter filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        Console.WriteLine("Journal loaded from file successfully.");
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose again.");
            }
        }
    }
}
