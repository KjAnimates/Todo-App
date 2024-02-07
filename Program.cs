using System;
using static System.Console;

namespace TodoApp;

public class Program
{
    public static String[] Tasks = { };

    public static void Main(String[] Args)
    {
        // Clear the Console
        Clear();

        WriteLine("Console Todo App");
        WriteLine("Your Tasks:");

        //TODO: List the user's tasks.
        if(Tasks.Length > 0)
        {
            for (int i = 0; i < Tasks.Length; i++)
            {
                string Task = Tasks[i];
                WriteLine($"  - {Tasks[i]}");
            }
        }
        else
        {
            ForegroundColor = ConsoleColor.Green;
            Write("  Woohoo! You're all done! :D");
            ResetColor();
            WriteLine();
        }
    }
}