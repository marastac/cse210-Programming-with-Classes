using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("¿what is your fist name?");
        string name = Console.ReadLine();    

        Console.Write("¿whats is your last_name?");
        string last = Console.ReadLine();

         Console.WriteLine($"Your name is {last}, {name} {last}. ");      
    }
}